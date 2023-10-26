using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Models
{
    public class Villians
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(EvilnessFactory))]
        public int EvilnessFactoryId { get; set; }

        public EvilnessFactory? EvilnessFactory { get; set; }
    }
}
