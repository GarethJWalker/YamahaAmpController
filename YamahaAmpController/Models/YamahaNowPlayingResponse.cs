using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YamahaAmpController.Models
{
    public class YamahaAmpControllerResponse
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class YAMAHA_AV
        {

            private YAMAHA_AVPlay_Info play_InfoField;

            private string rspField;

            private byte rcField;

            /// <remarks/>
            public YAMAHA_AVPlay_Info Play_Info
            {
                get
                {
                    return this.play_InfoField;
                }
                set
                {
                    this.play_InfoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string rsp
            {
                get
                {
                    return this.rspField;
                }
                set
                {
                    this.rspField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte RC
            {
                get
                {
                    return this.rcField;
                }
                set
                {
                    this.rcField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class YAMAHA_AVPlay_Info
        {

            private string feature_AvailabilityField;

            private string playback_InfoField;

            private YAMAHA_AVPlay_InfoPlay_Mode play_ModeField;

            private YAMAHA_AVPlay_InfoMeta_Info meta_InfoField;

            private YAMAHA_AVPlay_InfoAlbum_ART album_ARTField;

            private YAMAHA_AVPlay_InfoInput_Logo input_LogoField;

            /// <remarks/>
            public string Feature_Availability
            {
                get
                {
                    return this.feature_AvailabilityField;
                }
                set
                {
                    this.feature_AvailabilityField = value;
                }
            }

            /// <remarks/>
            public string Playback_Info
            {
                get
                {
                    return this.playback_InfoField;
                }
                set
                {
                    this.playback_InfoField = value;
                }
            }

            /// <remarks/>
            public YAMAHA_AVPlay_InfoPlay_Mode Play_Mode
            {
                get
                {
                    return this.play_ModeField;
                }
                set
                {
                    this.play_ModeField = value;
                }
            }

            /// <remarks/>
            public YAMAHA_AVPlay_InfoMeta_Info Meta_Info
            {
                get
                {
                    return this.meta_InfoField;
                }
                set
                {
                    this.meta_InfoField = value;
                }
            }

            /// <remarks/>
            public YAMAHA_AVPlay_InfoAlbum_ART Album_ART
            {
                get
                {
                    return this.album_ARTField;
                }
                set
                {
                    this.album_ARTField = value;
                }
            }

            /// <remarks/>
            public YAMAHA_AVPlay_InfoInput_Logo Input_Logo
            {
                get
                {
                    return this.input_LogoField;
                }
                set
                {
                    this.input_LogoField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class YAMAHA_AVPlay_InfoPlay_Mode
        {

            private string repeatField;

            private string shuffleField;

            /// <remarks/>
            public string Repeat
            {
                get
                {
                    return this.repeatField;
                }
                set
                {
                    this.repeatField = value;
                }
            }

            /// <remarks/>
            public string Shuffle
            {
                get
                {
                    return this.shuffleField;
                }
                set
                {
                    this.shuffleField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class YAMAHA_AVPlay_InfoMeta_Info
        {

            private string artistField;

            private string albumField;

            private string trackField;

            /// <remarks/>
            public string Artist
            {
                get
                {
                    return this.artistField;
                }
                set
                {
                    this.artistField = value;
                }
            }

            /// <remarks/>
            public string Album
            {
                get
                {
                    return this.albumField;
                }
                set
                {
                    this.albumField = value;
                }
            }

            /// <remarks/>
            public string Track
            {
                get
                {
                    return this.trackField;
                }
                set
                {
                    this.trackField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class YAMAHA_AVPlay_InfoAlbum_ART
        {

            private string uRLField;

            private ushort idField;

            private string formatField;

            /// <remarks/>
            public string URL
            {
                get
                {
                    return this.uRLField;
                }
                set
                {
                    this.uRLField = value;
                }
            }

            /// <remarks/>
            public ushort ID
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            public string Format
            {
                get
                {
                    return this.formatField;
                }
                set
                {
                    this.formatField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class YAMAHA_AVPlay_InfoInput_Logo
        {

            private string uRL_SField;

            private object uRL_MField;

            private object uRL_LField;

            /// <remarks/>
            public string URL_S
            {
                get
                {
                    return this.uRL_SField;
                }
                set
                {
                    this.uRL_SField = value;
                }
            }

            /// <remarks/>
            public object URL_M
            {
                get
                {
                    return this.uRL_MField;
                }
                set
                {
                    this.uRL_MField = value;
                }
            }

            /// <remarks/>
            public object URL_L
            {
                get
                {
                    return this.uRL_LField;
                }
                set
                {
                    this.uRL_LField = value;
                }
            }
        }


    }
}
