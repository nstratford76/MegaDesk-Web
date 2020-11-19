using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk_Web.Data;
using MegaDesk_Web.Models;

namespace MegaDesk_Web.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDesk_Web.Data.MegaDesk_WebContext _context;

        public IndexModel(MegaDesk_Web.Data.MegaDesk_WebContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync()
        {
            DeskQuote = await _context.DeskQuote.ToListAsync();
        }
    }
}
