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

    public class YamamaStatus
    {
        public int Volume { get; set; }
        public string Source { get; set; }

    }

    public class YamahaReceiver
    {
        private string endpoint = "http://192.168.1.141";
        private string ctrl = "/YamahaRemoteControl/ctrl";



        public YamamaStatus GetStatus()
        {
            var text = GetResponse($@"<YAMAHA_AV cmd=""GET""><Main_Zone><Basic_Status>GetParam</Basic_Status></Main_Zone></YAMAHA_AV>");
            XmlSerializer serializer = new XmlSerializer(typeof(YamahaStatusResponse.YAMAHA_AV));

            using (TextReader reader = new StringReader(text))
            {
                var result = serializer.Deserialize(reader) as YamahaStatusResponse.YAMAHA_AV;



                return new YamamaStatus()
                {
                    Volume = result.Main_Zone.Basic_Status.Volume.Lvl.Val,
                    Source = result.Main_Zone.Basic_Status.Input.Input_Sel

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
                    var result = serializer.Deserialize(reader) as YamahaAmpControllerResponse.YAMAHA_AV;
                    np.Artist = result.Play_Info.Meta_Info.Artist;
                    np.Album = result.Play_Info.Meta_Info.Album;
                    np.Title = result.Play_Info.Meta_Info.Track;
                    np.ArtURL = result.Play_Info.Album_ART.URL;
                    np.Status = result.Play_Info.Playback_Info;

                }
            } catch (WebException ex)
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
            } catch (WebException ex)
            {
                throw ex; 
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

        public void ChangeVolume(int change)
        {
            var v = new YamahaControl.VolumeControl();
            Send(v.Change(change).AsXML());
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
            xml = xml.Replace(@"<?xml version=""1.0"" encoding=""utf-16""?>", "");
            xml = xml.Replace("NULL_MARKER", "");
            return xml;
        }


    }
}
