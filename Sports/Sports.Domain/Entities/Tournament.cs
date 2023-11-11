using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;


namespace Sports.Domain.Entities
{
    public class Tournament
    {
        [Key]
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string? TournamentVideo { get; set; }
        
    }
}
