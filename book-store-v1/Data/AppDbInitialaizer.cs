using book_store_v1.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_store_v1.Data
{
    public class AppDbInitialaizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var ServicesScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = ServicesScope.ServiceProvider.GetService<ApplicationDbContext>();
                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "First Book",
                        Description = "Fist Book Desciption...",
                        CoverUrl = "http...",
                        DateAdded = DateTime.Now.AddDays(-5),
                        DateRead = DateTime.Now,
                        Genre = "Comedy",
                        IsRead = true,
                        Rate = 7
                    },
                    new Book
                    {
                        Title = "Second Book",
                        Description = "Second Book Desciption...",
                        CoverUrl = "http...",
                        DateAdded = DateTime.Now.AddDays(-5),                        
                        Genre = "Comedy",
                        IsRead = false,
                    }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
