using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Till
    {
        [Key]
        public int TillId { get; set; }
        public string Date { get; set; }
        public decimal TotelMoney { get; set; }
    }
}
