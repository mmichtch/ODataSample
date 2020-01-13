using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataSample.Model
{
    public class TextBook
    {
        public virtual int Id { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Content { get; set; }
    }
}
