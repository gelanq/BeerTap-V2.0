using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeerTap.Data.Models
{
   public class GlassEntity
    {
       public int TapId { get; set; }

      
        public int Id { get; set; }

     
        public double AmountToPour { get; set; }
        [ForeignKey("TapId")]

        private TapEntity Tap { get; set; }
    }
}
