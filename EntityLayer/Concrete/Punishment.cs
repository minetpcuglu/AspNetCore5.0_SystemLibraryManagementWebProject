using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Punishment
    {
        [Key]
        public int PunishmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public decimal Money { get; set; }


        /*İlişkiler*/
        public int? UserId { get; set; }
        public virtual User User { get; set; }


        /*İlişkiler*/
        public int MovementId { get; set; }
        public virtual Movement Movement { get; set; }

       

    }
}
