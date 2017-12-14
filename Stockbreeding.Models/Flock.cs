using System;

namespace Stockbreeding.Models
{
    [Serializable()]
    public class Flock
    {
        [System.Xml.Serialization.XmlElement("ID")]
        public int ID { get; set; }
        [System.Xml.Serialization.XmlElement("AnimalType")]
        public string AnimalType { get; set; }
        [System.Xml.Serialization.XmlElement("Below1Year")]
        public uint Below1Year { get; set; }
        [System.Xml.Serialization.XmlElement("From1To3Years")]
        public uint From1To3Years { get; set; }
        [System.Xml.Serialization.XmlElement("Above1Year")]
        public uint Above1Year { get; set; }
        [System.Xml.Serialization.XmlElement("MortalityRate")]
        public float MortalityRate { get; set; }
        [System.Xml.Serialization.XmlElement("BirthRate")]
        public float BirthRate { get; set; }
    }
}