using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Domain.DTOs
{
    public record TeamDTO
    {
        public int? TeamId { get; set; }
        [StringLength(50) ]
        public string TeamName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Website { get; set; }
        public string? Logo { get; set; }
        public IFormFile? LogoFile { get; set; }
        public DateTime FoundationDate { get; set; }
    }
}
