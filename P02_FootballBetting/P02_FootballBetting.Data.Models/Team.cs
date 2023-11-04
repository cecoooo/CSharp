using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [Unicode]
        public string Name { get; set; }

        [Unicode]
        public string LogoUrl { get; set; }

        [Required]
        [Unicode]
        public string Initials { get; set; }

        public decimal Budget { get; set; }

        [ForeignKey(nameof(PrimaryKitColor))]
        [Required]
        public int PrimaryKitColorId { get; set; }

        [ForeignKey(nameof(SecondaryKitColor))]
        [Required]
        public int SecondaryKitColorId { get; set; }

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }

        [InverseProperty(nameof(Game.HomeTeam))]
        public ICollection<Game> HomeGames { get; set; }

        [InverseProperty(nameof(Game.AwayTeam))]

        public ICollection<Game> AwayGames { get; set; }
        public ICollection<Player> Players { get; set; }
        public Color PrimaryKitColor { get; set; }
        public Color SecondaryKitColor { get; set; }
        public Town Town { get; set; }
    }
}
