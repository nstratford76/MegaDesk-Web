using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDesk_Web.Models;

namespace MegaDesk_Web.Data
{
    public class MegaDesk_WebContext : DbContext
    {
        public MegaDesk_WebContext (DbContextOptions<MegaDesk_WebContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDesk_Web.Models.DeskQuote> DeskQuote { get; set; }
        public DbSet<DesktopMaterial> DesktopMaterials { get; set; }
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<Desk> Desks { get; set; }
    }
}
