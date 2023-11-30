using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("cars")]
    public class CarExportWithIds
    {
        [XmlElement("id")]
        public int Id { get; set; }
        
        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("traveled-distance")]
        public long TraveledDistance { get; set; }
    }
}
