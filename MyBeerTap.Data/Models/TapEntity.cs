using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeerTap.Data.Models
{
 

    [Table("Taps")]
    public class TapEntity 
    {

         
        public int Id { get; set; }

      
        public string Label { get; set; }

       
        public int OfficeId { get; set; }

   
        [ForeignKey("OfficeId")]
        public OfficeEntity Office { get; set; }

 
        public virtual KegEntity Keg { get; set; }
        public List<GlassEntity> Glasses { get; set; }


    }
}
