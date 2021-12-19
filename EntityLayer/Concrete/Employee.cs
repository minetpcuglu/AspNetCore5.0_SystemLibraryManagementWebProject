using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string NameSurname { get; set; }

        /*İlişkiler*/
        public ICollection<Movement> Movements { get; set; }
        /**/
    }
}
