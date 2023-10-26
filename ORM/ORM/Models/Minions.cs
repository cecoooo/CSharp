using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Models
{
    public class Minions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; }
    }
}
