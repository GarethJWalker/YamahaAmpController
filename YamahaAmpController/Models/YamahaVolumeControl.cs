using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YamahaControl
{



        public class VolumeControl
        {

            public YAMAHA_AV Change(int change)
            {
                var y = new YAMAHA_AV();
                y.cmd = "PUT";
                y.Main_Zone = new YAMAHA_AV_Zone();                
                y.Main_Zone.Volume = new YAMAHA_AV_ZoneVolume();
                y.Main_Zone.Volume.Lvl = new YAMAHA_AV_ZoneVolumeLvl();
                y.Main_Zone.Volume.Lvl.Val = $"{(change>0 ? "Up" : "Down")} {Math.Abs(change)} dB";
                y.Main_Zone.Volume.Lvl.Exp = "NULL_MARKER";
                y.Main_Zone.Volume.Lvl.Unit = "NULL_MARKER";
                return y;
            }
            public YAMAHA_AV ChangeZone2(int change)
            {
                var y = new YAMAHA_AV();
                y.cmd = "PUT";
                y.Main_Zone = new YAMAHA_AV_Zone();

                y.Main_Zone.Volume = new YAMAHA_AV_ZoneVolume();
                y.Main_Zone.Volume.Zone_B = new YAMAMA_AZ_ZoneB();
                y.Main_Zone.Volume.Zone_B.Lvl = new YAMAHA_AV_ZoneVolumeLvl();
                y.Main_Zone.Volume.Zone_B.Lvl.Val = $"{(change > 0 ? "Up" : "Down")} {Math.Abs(change)} dB";
                y.Main_Zone.Volume.Zone_B.Lvl.Exp = "NULL_MARKER";
                y.Main_Zone.Volume.Zone_B.Lvl.Unit = "NULL_MARKER";
                return y;
            }

        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
            public partial class YAMAHA_AV
            {

                private YAMAHA_AV_Zone main_ZoneField;

                private string cmdField;

                
                public YAMAHA_AV_Zone Main_Zone
                {
                    get
                    {
                        return this.main_ZoneField;
                    }
                    set
                    {
                        this.main_ZoneField = value;
                    }
                }

                [System.Xml.Serialization.XmlAttributeAttribute()]
                public string cmd
                {
                    get
                    {
                        return this.cmdField;
                    }
                    set
                    {
                        this.cmdField = value;
                    }
                }
            }

            
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            public partial class YAMAHA_AV_Zone
            {

                private YAMAHA_AV_ZoneVolume volumeField;



                public YAMAHA_AV_ZoneVolume Volume
                {
                    get
                    {
                        return this.volumeField;
                    }
                    set
                    {
                        this.volumeField = value;
                    }
                }
            }

            
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            public partial class YAMAHA_AV_ZoneVolume
            {

                private YAMAHA_AV_ZoneVolumeLvl lvlField;
                public YAMAMA_AZ_ZoneB Zone_B;


                public YAMAHA_AV_ZoneVolumeLvl Lvl
                {
                    get
                    {
                        return this.lvlField;
                    }
                    set
                    {
                        this.lvlField = value;
                    }
                }
            }

            
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            public partial class YAMAHA_AV_ZoneVolumeLvl
            {

                private string valField;

                private string expField;

                private string unitField;

                
                public string Val
                {
                    get
                    {
                        return this.valField;
                    }
                    set
                    {
                        this.valField = value;
                    }
                }

                
                public string Exp
                {
                    get
                    {
                        return this.expField;
                    }
                    set
                    {
                        this.expField = value;
                    }
                }

                
                public string Unit
                {
                    get
                    {
                        return this.unitField;
                    }
                    set
                    {
                        this.unitField = value;
                    }
                }
            }


        }

    public class YAMAMA_AZ_ZoneB : VolumeControl.YAMAHA_AV_ZoneVolume
    {
    }
}

