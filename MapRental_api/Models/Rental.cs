using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MapRental_api.Models
{
    [Table("Rental")]
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Rent { get; set; }

        [Required]
        public string Contact { get; set; }

        public int UserId { get; set; }

    }
}
