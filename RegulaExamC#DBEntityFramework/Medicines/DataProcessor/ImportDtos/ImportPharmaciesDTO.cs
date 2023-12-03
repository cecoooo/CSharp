using Medicines.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Car")]
    public class ImportPharmaciesDTO
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlArray("Medicines")]
        public ImportMedicineDTO[] Medicines{ get; set; }
    }
}
