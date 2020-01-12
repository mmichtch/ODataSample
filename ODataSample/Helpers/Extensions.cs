using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using ODataSample.Data;

namespace ODataSample.Helpers
{
    public static class Extensions
    {
        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<LibraryContext>();
            context.Database.Migrate();

            return app;
        }

    }
}
