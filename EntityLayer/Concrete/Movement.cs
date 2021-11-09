using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Movement
    {
        [Key]
        public int MovementId { get; set; }
        //public int EmployeeId { get; set; }
        public DateTime AlisTarihi { get; set; }

        public DateTime IadeTarihi { get; set; }

        /*İlişkiler*/
        public int BookId { get; set; }
        public virtual Book Book { get; set; }


        /*İlişkiler*/
        public int UserId { get; set; }
        public virtual User User { get; set; }


        /*İlişkiler*/
        public ICollection<Punishment> Punishments { get; set; }
        /**/
    }
}
