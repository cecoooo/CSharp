﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        [Unicode]
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }
    }
}
