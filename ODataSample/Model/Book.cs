using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataSample.Model
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<BookAuthor>();
            Genres = new HashSet<BookGenre>();
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual BookType Type { get; set; }
        public virtual CookBook CookBook { get; set; }
        public virtual TextBook TextBook { get; set; }
        public virtual RoadAtlas RoadAtlas { get; set; }
        public virtual IEnumerable<BookAuthor> Authors { get; set; }
        public virtual IEnumerable<BookGenre> Genres { get; set; }
    }
}
