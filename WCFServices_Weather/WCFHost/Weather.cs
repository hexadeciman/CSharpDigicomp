using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WCFHost
{
    [XmlRoot("rss")]
    public class Weather
    {
        [XmlElement("channel")]
        public Channel Channel { get; set; }
    }

    public class Channel
    {
        [XmlElement("title")]
        public string Title
        {
            get; set;
        }
        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("language")]
        public string Language { get; set; }

        [XmlElement("lastBuildDate")]
        public string LastBuildDate { get; set; }

        [XmlElement("ttl")]
        public int Ttl { get; set; }

        [XmlElement("item")]
        public Item[] Items { get; set; }

        [XmlElement("image")]
        public Image Image { get; set; }
    }

    public class Image
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("width")]
        public int Width { get; set; }

        [XmlElement("height")]
        public int Height { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }
    }
    public class Item
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("pubDate")]
        public string PubDate { get; set; }
    }
}
