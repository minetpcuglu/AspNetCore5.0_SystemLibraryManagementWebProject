using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Telephone { get; set; }
        public string Education { get; set; }
        public bool UserStatus { get; set; }

        /*İlişkiler*/
        public ICollection<Punishment> Punishments { get; set; }


        /*İlişkiler*/
        public ICollection<Movement> Movements { get; set; }

        public virtual ICollection<Message> UserSender { get; set; }
        public virtual ICollection<Message> UserReceiver { get; set; }
    }
}
