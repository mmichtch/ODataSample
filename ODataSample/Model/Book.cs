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

        public int Id { get; set; }
        public string Name { get; set; }

        public BookType Type { get; set; }

        public CookBook CookBook { get; set; }
        public TextBook TextBook { get; set; }
        public RoadAtlas RoadAtlas { get; set; }

        public IEnumerable<BookAuthor> Authors { get; set; }
        public IEnumerable<BookGenre> Genres { get; set; }
    }
}
