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
                y.Main_Zone = new YAMAHA_AVMain_Zone();                
                y.Main_Zone.Volume = new YAMAHA_AVMain_ZoneVolume();
                y.Main_Zone.Volume.Lvl = new YAMAHA_AVMain_ZoneVolumeLvl();
                y.Main_Zone.Volume.Lvl.Val = $"{(change>0 ? "Up" : "Down")} {Math.Abs(change)} dB";
                y.Main_Zone.Volume.Lvl.Exp = "NULL_MARKER";
                y.Main_Zone.Volume.Lvl.Unit = "NULL_MARKER";
                return y;
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
            public partial class YAMAHA_AV
            {

                private YAMAHA_AVMain_Zone main_ZoneField;

                private string cmdField;

                /// <remarks/>
                public YAMAHA_AVMain_Zone Main_Zone
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

                /// <remarks/>
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

            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            public partial class YAMAHA_AVMain_Zone
            {

                private YAMAHA_AVMain_ZoneVolume volumeField;

                /// <remarks/>
                public YAMAHA_AVMain_ZoneVolume Volume
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

            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            public partial class YAMAHA_AVMain_ZoneVolume
            {

                private YAMAHA_AVMain_ZoneVolumeLvl lvlField;

                /// <remarks/>
                public YAMAHA_AVMain_ZoneVolumeLvl Lvl
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

            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            public partial class YAMAHA_AVMain_ZoneVolumeLvl
            {

                private string valField;

                private string expField;

                private string unitField;

                /// <remarks/>
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

                /// <remarks/>
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

                /// <remarks/>
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
    }

