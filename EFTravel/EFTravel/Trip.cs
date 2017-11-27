using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTravel
{
    class Trip
    {
        //primary key
        [Key]
       public int TripId { get; set; } //identity
        [MinLength(2)][MaxLength(50)]
       public string TravelerName { get; set; }//2-50 characters
        [MinLength(2)][MaxLength(50)]
       public string FromWhere { get; set; } //2-50 characters
        [MinLength(2)][MaxLength(50)]
       public string ToWhere { get; set; } //2-50 characters
      public DateTime DepartureDate { get; set; } //Date only input yyyy-mm-dd

    }
}
