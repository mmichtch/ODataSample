using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataSample.Model
{
    public class CookBook
    {
        public virtual int Id { get; set; }
        public virtual string Theme { get; set; }
        public virtual IEnumerable<CookRecipe> Recipes { get; set; }
        public virtual IEnumerable<CookBookBlogEntry> BlogEntries { get; set; }
    }

}
