using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Classes
{
  public class BookAbout
    {
        public IEnumerable<Book> Book1{ get; set; }
        public IEnumerable<About> About1{ get; set; }
    }
}
