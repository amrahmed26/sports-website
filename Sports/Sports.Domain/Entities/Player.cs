
using System.ComponentModel.DataAnnotations;


namespace Sports.Domain.Entities
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public DateTime BirtDate { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
