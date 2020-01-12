using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using ODataSample.Data;
using ODataSample.Model;
using ODataSample.Helpers;

namespace ODataSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>(options => {


                options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                        opt => { /*opt.EnableRetryOnFailure(); opt.CommandTimeout();*/ }
                    );
            },
            contextLifetime: ServiceLifetime.Scoped,
            optionsLifetime: ServiceLifetime.Scoped);

            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UpdateDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //    //endpoints.MapODataServiceRoute("odata", "odata", GetEdmModel());
            //});
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var esBooks = builder.EntitySet<Book>("Books");
            var etBook = esBooks.EntityType;

            builder.EntityType<BookAuthor>().HasKey(e => e.AuthorId);
            etBook.ContainsMany(e => e.Authors);

            builder.EntityType<BookGenre>().HasKey(e => e.GenreId);
            etBook.ContainsMany(e => e.Genres);
            
            etBook.ContainsOptional(e => e.CookBook);
            etBook.ContainsOptional(e => e.TextBook);
            etBook.ContainsOptional(e => e.RoadAtlas);


            builder.EntitySet<Author>("Authors");
            builder.EntitySet<Genre>("Genres");
            return builder.GetEdmModel();
        }
    }
}
