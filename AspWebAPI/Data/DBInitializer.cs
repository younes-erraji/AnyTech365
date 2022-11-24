using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using AspWebAPI.Data.Models;

namespace AspWebAPI.Data
{
    public class DBInitializer
    {
        public async static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (IServiceScope scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                _DBContext context = scope.ServiceProvider.GetService<_DBContext>();
                if (context.Books.Any() == false)
                {
                    await context.Books.AddRangeAsync(
                        new Book { Title = "X-Men", Genre = "Action", /* Rate = 4.7f, */ Author_ID = 1, Price = 17.23M },
                        new Book { Title = "One Piece", Genre = "Adventures", /* Rate = 3.4f, */ Author_ID = 1, Price = 37.23M }
                    );

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
