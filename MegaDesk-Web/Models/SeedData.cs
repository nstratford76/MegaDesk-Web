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

                var materials = new DesktopMaterial[]
                {
                    new DesktopMaterial {Name = "Laminate", Price = 100},
                    new DesktopMaterial {Name = "Oak", Price = 200 },
                    new DesktopMaterial {Name = "Rosewood", Price = 300 },
                    new DesktopMaterial {Name = "Pine", Price = 50 },
                    new DesktopMaterial {Name = "Veneer", Price = 125 }
                };

                foreach(DesktopMaterial m in materials)
                {
                    context.DesktopMaterials.Add(m);
                }

                var shipping = new Shipping[]
                {
                    new Shipping {RushOrder = "3 Day", RushPrices = {60, 70, 80 } },
                    new Shipping {RushOrder = "5 Day", RushPrices = {40, 50, 60 } },
                    new Shipping {RushOrder = "7 Day", RushPrices = {30, 35, 40 } }
                };

                foreach(Shipping s in shipping)
                {
                    context.Shipping.Add(s);
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
