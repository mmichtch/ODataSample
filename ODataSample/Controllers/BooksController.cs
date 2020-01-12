using System.Linq;

using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

using ODataSample.Data;
using ODataSample.Model;

namespace ODataSample.Controllers
{
    [ODataRoutePrefix("Books")]
    public class BooksController : ODataController
    {
        private readonly LibraryContext db;

        public BooksController(LibraryContext dbContext)
        {
            this.db = dbContext;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Book> Get()
        {
            return db.Books.AsQueryable();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<Book> Get(int key)
        {
            return SingleResult.Create(db.Books.Where(c => c.Id == key));
        }
    }
}
