using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeerTap.Data.Models
{
    [Table("Offices")]
    public class OfficeEntity  
    {
    

        public int Id { get; set; }
        public string Name { get; set; }
        public List<TapEntity> Taps { get; set; }
    }
}
