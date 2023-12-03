using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{

    /*
     <Address>
    <StreetName>Gnigler strasse</StreetName>
    <StreetNumber>57</StreetNumber>
    <PostCode>5020</PostCode>
    <City>Salzburg</City>
    <Country>Austria</Country>
     */

    [XmlType("Address")]
    public class ImportAddressDTO
    {
        [XmlElement("StreetName")]
        public string StreetName { get; set; }

        [XmlElement("StreetNumber")]
        public int StreetNumber { get; set; }

        [XmlElement("PostCode")]
        public int PostCode { get; set; }

        [XmlElement("City")]
        public string City { get; set; }

        [XmlElement("Country")]
        public string Country { get; set; }
    }
}
