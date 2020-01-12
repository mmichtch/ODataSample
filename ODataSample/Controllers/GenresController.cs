using System.Linq;

using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

using ODataSample.Data;
using ODataSample.Model;


namespace ODataSample.Controllers
{
    [ODataRoutePrefix("[controller]")]
    public class GenresController
    {
        private readonly LibraryContext db;

        public GenresController(LibraryContext dbContext)
        {
            this.db = dbContext;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Genre> Get()
        {
            return db.Genres.AsQueryable();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<Genre> Get(int key)
        {
            return SingleResult.Create(db.Genres.Where(c => c.Id == key));
        }


    }
}
