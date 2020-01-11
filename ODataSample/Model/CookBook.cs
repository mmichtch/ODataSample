using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataSample.Model
{
    public class CookBook
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public IEnumerable<CookRecipe> Recipes { get; set; }
    }
}
