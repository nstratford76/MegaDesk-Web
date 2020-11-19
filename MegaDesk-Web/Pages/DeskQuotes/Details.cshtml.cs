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
    public class DetailsModel : PageModel
    {
        private readonly MegaDesk_Web.Data.MegaDesk_WebContext _context;

        public DetailsModel(MegaDesk_Web.Data.MegaDesk_WebContext context)
        {
            _context = context;
        }

        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote.FirstOrDefaultAsync(m => m.DeskQuoteID == id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
