using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        [Unicode]
        public string Name { get; set; }
        public int SquadNumber { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }

        [Required]
        public bool IsInjured { get; set; }

        public Team Team { get; set; }
        public Position Position { get; set; }
        public PlayerStatistic playersStatistic { get; set; }
    }
}
