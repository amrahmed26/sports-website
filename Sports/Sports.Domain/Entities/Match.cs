
using System.ComponentModel.DataAnnotations;

namespace Sports.Domain.Entities
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public int TournamentId { get; set; }
        [StringLength(10)]
        public string Result { get; set; }
        public DateTime MatchDate { get; set; }
        public virtual Team Home { get; set; }
        public virtual Team Away { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
