using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace API.ParamModels
{

    [XmlRoot(ElementName = "dictionary")]
    public class Dictionary
    {
        [XmlElement(ElementName = "root")]
        public List<Root> Roots { get; set; }
    }

    [XmlRoot(ElementName = "root")]
    public class Root
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "gloss")]
        public string Gloss { get; set; }

        [XmlElement(ElementName = "form")]
        public string Form { get; set; }

        [XmlElement(ElementName = "EnglishWords")]
        public EnglishWords EnglishWords { get; set; }

        [XmlElement(ElementName = "category")]
        public string Category { get; set; }

        [XmlElement(ElementName = "level")]
        public string Level { get; set; }

        [XmlElement(ElementName = "topics")]
        public Topics Topics { get; set; }

        [XmlElement(ElementName = "isNull")]
        public bool IsNull { get; set; }

        [XmlElement(ElementName = "rootword")]
        public string Rootword { get; set; }

        [XmlElement(ElementName = "inflectedforms")]
        public Inflectedforms Inflectedforms { get; set; }

        [XmlElement(ElementName = "scientificname")]
        public string Scientificname { get; set; }

        [XmlElement(ElementName = "image")]
        public string Image { get; set; }

        [XmlElement(ElementName = "latitude")]
        public float Latitude { get; set; }

        [XmlElement(ElementName = "longitude")]
        public float Longitude { get; set; }
    }


    [XmlRoot(ElementName = "EnglishWords")]
    public class EnglishWords
    {
        [XmlElement(ElementName = "EnglishWord")]
        public List<string> EnglishWord { get; set; }
    }

    [XmlRoot(ElementName = "topics")]
    public class Topics
    {
        [XmlElement(ElementName = "title")]
        public List<string> Title { get; set; }
    }

    [XmlRoot(ElementName = "inflectedforms")]
    public class Inflectedforms
    {
        [XmlElement(ElementName = "element")]
        public List<Element> Elements { get; set; }
    }




    [XmlRoot(ElementName = "element")]
    public class Element
    {
        [XmlElement(ElementName = "inflectedform")]
        public string Inflectedform { get; set; }
        [XmlElement(ElementName = "inflectedformtranslation")]
        public string Inflectedformtranslation { get; set; }
        [XmlElement(ElementName = "audio")]
        public List<string> Audios { get; set; }
        [XmlElement(ElementName = "examples")]
        public List<Example> Examples { get; set; }
        [XmlElement(ElementName = "attributes")]
        public List<Attribute> Attributes { get; set; }
    }





    [XmlRoot(ElementName = "examples")]
    public class Example
    {

        [XmlElement(ElementName = "element")]
        public ExampleElement ExampleElement { get; set; }
    }

    [XmlRoot(ElementName = "element")]
    public class ExampleElement
    {
        [XmlElement(ElementName = "sekani")]
        public string Sekani { get; set; }
        [XmlElement(ElementName = "english")]
        public string English { get; set; }
        [XmlElement(ElementName = "audio")]
        public string Audio { get; set; }
    }

    [XmlRoot(ElementName = "attributes")]
    public class Attribute
    {
        [XmlElement(ElementName = "element")]
        public AttributeElement AttributeElement { get; set; }
    }


    public class AttributeElement
    {
        [XmlElement(ElementName = "key")]
        public string Key { get; set; }
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }
}
