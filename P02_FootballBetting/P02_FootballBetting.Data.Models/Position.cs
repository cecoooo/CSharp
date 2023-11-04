using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }
        [Required]
        [Unicode]
        public int Name { get; set; }
    }
}
