using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Domain.ViewModels
{
    public class TournamentUpdateViewModel
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string? TournamentVideo { get; set; }
        public string? Teams { get; set; }
    }
}
