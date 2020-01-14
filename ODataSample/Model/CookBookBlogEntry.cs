using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataSample.Model
{
    public class CookBookBlogEntry
    {
        public int Id { get; set; }
        public int CookBookId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public CookBook CookBook { get; set; }

    }
}
