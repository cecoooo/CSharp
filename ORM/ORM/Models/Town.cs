using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Models
{
    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(Country))]
        public int? CountryCode { get; set; }
        public Country? Country { get; set; }

        public Town(string name, int code) 
        {
            this.Name = name;
            this.CountryCode = code;
        }

        public Town()
        {

        }

    }
}
