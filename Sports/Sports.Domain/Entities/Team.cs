
using System.ComponentModel.DataAnnotations;


namespace Sports.Domain.Entities
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [StringLength(50)]
        public string TeamName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Website { get; set; }
        [StringLength(100)]
        public string Logo { get; set; }
        public DateTime FoundationDate  { get; set; }
    }
}
