using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Domain.DTOs
{
    public record PlayerDTO
    {
        public int PlayerId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public DateTime BirtDate { get; set; }
        public int TeamId { get; set; }
    }
}
