using Microsoft.AspNetCore.Http;
using Sports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Domain.DTOs
{
    public record TournamentDTO
    {
        public int?TournamentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? Logo { get; set; }
        public string? LogoLink { get; set; }
        public string? TournamentVideo { get; set; }
        public List<int>TeamIds { get; set; }
    }
}
