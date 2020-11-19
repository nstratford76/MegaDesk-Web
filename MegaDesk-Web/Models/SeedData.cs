using MegaDesk_Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDesk_Web.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDesk_WebContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MegaDesk_WebContext>>()))
            {
                if (context.DeskQuote.Any())
                {
                    return;   // DB has been seeded
                }

                context.DeskQuote.AddRange(
                    new DeskQuote
                    {
                        
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
