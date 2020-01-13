using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataSample.Model
{
    public class BookAuthor
    {
        public virtual int BookId { get; set; }
        public virtual int AuthorId { get; set; }
        public virtual Book Book{ get; set; }
        public virtual Author Author { get; set; }

    }
}
