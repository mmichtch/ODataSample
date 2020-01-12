using System.Linq;

using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

using ODataSample.Data;
using ODataSample.Model;


namespace ODataSample.Controllers
{
    [ODataRoutePrefix("[controller]")]
    public class AuthorsController
    {
        private readonly LibraryContext db;

        public AuthorsController(LibraryContext dbContext)
        {
            this.db = dbContext;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Author> Get()
        {
            return db.Authors.AsQueryable();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<Author> Get(int key)
        {
            return SingleResult.Create(db.Authors.Where(c => c.Id == key));
        }


    }
}
