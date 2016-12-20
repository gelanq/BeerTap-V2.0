 
using System.ComponentModel.DataAnnotations.Schema;
using MyBeerTap.Model;
  

namespace MyBeerTap.Data.Models

{




    [Table("Kegs")]
    public class KegEntity
    { 
        public int Id { get; set; }

       
        public BeerName Beer { get; set; }

      
        public double Capacity { get; set; }

        
        public KegSize Size { get; set; }


         
        public double Remaining { get; set; }

 
        public int? TapId { get; set; }

        public TapEntity Tap { get; set; }

    }
}
