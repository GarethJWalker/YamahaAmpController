using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using YamahaAmpController.Models;
using System.Xml;
using System.Web;

namespace YamahaAmpController
{
    public class NowPlayingInfo
    {
        public string Source { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Title { get; set; }
        public string ArtURL { get; set; }
        public string Status { get; set; }
    }

    public class YamahaStatus
    {
        public int Volume { get; set; }
        public string Source { get; set; }
        public string MainZoneMute { get; set; }
        public string ZoneBMute { get; set; }
        public short MainZoneVolume { get; set; }
        public short ZoneBVolume { get; set; }
    }

    public class YamahaReceiver
    {
        private string endpoint = "http://192.168.1.141";
        private string ctrl = "/YamahaRemoteControl/ctrl";
        public YamahaStatus GetStatus()
        {
            var text = GetResponse($@"<YAMAHA_AV cmd=""GET""><Main_Zone><Basic_Status>GetParam</Basic_Status></Main_Zone></YAMAHA_AV>");
            XmlSerializer serializer = new XmlSerializer(typeof(YamahaStatusResponse.YAMAHA_AV));

            using (TextReader reader = new StringReader(text))
            {
                var result = serializer.Deserialize(reader) as YamahaStatusResponse.YAMAHA_AV;
                return new YamahaStatus()
                {
                    Volume = result.Main_Zone.Basic_Status.Volume.Lvl.Val,
                    Source = result.Main_Zone.Basic_Status.Input.Input_Sel,
                    MainZoneMute = result.Main_Zone.Basic_Status.Volume.Mute,
                    ZoneBMute = result.Main_Zone.Basic_Status.Volume.Zone_B.Mute,
                    MainZoneVolume = result.Main_Zone.Basic_Status.Volume.Lvl.Val,
                    ZoneBVolume = result.Main_Zone.Basic_Status.Volume.Zone_B.Lvl.Val
                };
            }
        }

        public NowPlayingInfo NowPlaying()
        {
            var np = new NowPlayingInfo();
            try
            {
                var text = GetResponse($@"<YAMAHA_AV cmd=""GET""><{Source}><Play_Info>GetParam</Play_Info></{Source}></YAMAHA_AV>").Replace($@"<{Source}>", "").Replace($@"</{Source}>", "");
                XmlSerializer serializer = new XmlSerializer(typeof(YamahaAmpControllerResponse.YAMAHA_AV));
                using (TextReader reader = new StringReader(text))
                {
                    if (text.Contains("Not Ready"))  return new NowPlayingInfo() { Status = "Stopped" };
                    var result = serializer.Deserialize(reader) as YamahaAmpControllerResponse.YAMAHA_AV;
                    if (result.Play_Info == null) return new NowPlayingInfo() { Status = "Stopped" }; ;
                    np.Artist = HttpUtility.HtmlDecode(result.Play_Info.Meta_Info.Artist);
                    np.Album = HttpUtility.HtmlDecode(result.Play_Info.Meta_Info.Album);
                    np.Title = HttpUtility.HtmlDecode(result.Play_Info.Meta_Info.Track ?? result.Play_Info.Meta_Info.Song);
                    np.ArtURL = result.Play_Info.Album_ART?.URL;
                    np.Status = result.Play_Info.Playback_Info;

                }
            } catch (WebException) //TODO: Check for more appropriate error
            {
                return new NowPlayingInfo() { Status = "Non supported" };
            }            
            return np;
        }

        public string GetResponse(string xml)
        {
            var request = (HttpWebRequest)WebRequest.Create(endpoint + ctrl);

            var data = Encoding.ASCII.GetBytes(xml);

            request.Method = "POST";
            request.ContentType = "application/xml";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            } catch (WebException)
            {
                throw; 
            }


        }

        public Image GetImage(string image)
        {
            if (string.IsNullOrEmpty(image)) return null;
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData($@"{endpoint}{image}");
            MemoryStream ms = new MemoryStream(bytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }

        public void ChangeVolume(int change, int zone=1)
        {
            var v = new YamahaControl.VolumeControl();
            if (zone == 1) Send(v.Change(change).AsXML());
            if (zone==2) Send(v.ChangeZone2(change).AsXML());
        }

        public void ToggleMute(int zone)
        {
            if (zone == 1)
            {
                var newStatus = GetStatus().MainZoneMute == "On" ? "Off" : "On";
                Send("\'<YAMAHA_AV cmd=\"PUT\"><Main_Zone><Volume><Mute>" + newStatus+ "</Mute></Volume></Main_Zone></YAMAHA_AV>\'");
            }

            if (zone == 2)
            {
                var newStatus = GetStatus().ZoneBMute == "On" ? "Off" : "On";
                Send("<YAMAHA_AV cmd=\"PUT\"><Main_Zone><Volume><Zone_B><Mute>" + newStatus + "</Mute></Zone_B></Volume></Main_Zone></YAMAHA_AV>");
            }


        }


        public void Pause() => PlayControl("Pause");

        public void Play() => PlayControl("Play");

        public void Forward() => PlayControl("Skip Fwd");

        public void Backward() => PlayControl("Skip Rev");
        private void PlayControl(string text)
        {

            var xml = $@"<YAMAHA_AV cmd=""PUT"">
                  <{Source}>
                    <Play_Control>
                        <Playback>{text}</Playback>
	                </Play_Control>
                    </{Source}>
                </YAMAHA_AV>";

            Send(xml);
        }

        private string Source => GetStatus().Source;


        public void Send(string xml)
        {
            var request = (HttpWebRequest)WebRequest.Create(endpoint + ctrl);

            var data = Encoding.ASCII.GetBytes(xml);
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }


    }



    public static class YamahaExtensions
    {
        public static string AsXML<T>(this T obj)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            var xml = "";
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.GetEncoding("ISO-8859-1");
            settings.NewLineChars = Environment.NewLine;
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.Indent = true;
            using (var sww = new StringWriter())
            {
                using (var writer = XmlWriter.Create(sww, settings))
                {

                    xsSubmit.Serialize(writer, obj, namespaces);
                    xml = sww.ToString();
                }
            }
            // Amp doesn't like this!
            xml = xml.Replace(@"<?xml version=""1.0"" encoding=""utf-16""?>", "");
            // Also doesn't like short tags so this is a hacky way round it
            xml = xml.Replace("NULL_MARKER", "");
            return xml;
        }


    }
}
