using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Medicine")]
    public class ImportMedicineDTO
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }

        [XmlElement("ProductionDate")]
        public DateTime ProductionDate { get; set; }

        [XmlElement("ExpiryDate")]
        public DateTime ExpiryDate { get; set; }

        [XmlElement("Producer")]
        public string Producer { get; set; }
    }
}
