using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Unicode]
        public string Username { get; set; }

        [Required]
        [Unicode]
        public string Password { get; set; }

        [Required]
        [Unicode]
        public string Email { get; set; }

        [Required]
        [Unicode]
        public string Name { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
