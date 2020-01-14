using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataSample.Model
{
    public class CookBookBlogEntry
    {
        public virtual int Id { get; set; }
        public virtual int CookBookId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Content { get; set; }
        public virtual CookBook CookBook { get; set; }

    }
}
