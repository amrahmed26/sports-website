using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Domain.Entities
{
    public class TeamTournament
    {
        public int TeamId { get; set; }
        public int TournamentId { get; set; }
        public virtual Team Team { get; set; }
        public virtual Tournament Tournament { get; set; }
    }
}
