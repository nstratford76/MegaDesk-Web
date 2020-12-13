using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk_Web.Data;
using MegaDesk_Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public string SearchString { get; set; }

        public SelectList Shipping { get; set; }

        public string ShippingOption { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> shippingQuery = from s in _context.Shipping
                                               orderby s.RushOrder
                                               select s.RushOrder;

            var quotes = from q in _context.DeskQuote
                         select q;

            if (!string.IsNullOrEmpty(SearchString))
            {
                quotes = quotes.Where(q => q.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ShippingOption))
            {
                quotes = quotes.Where(q => q.Shipping.RushOrder == ShippingOption);
            }
            Shipping = new SelectList(await shippingQuery.Distinct().ToListAsync());
            DeskQuote = await _context.DeskQuote.ToListAsync();
        }
    }
}
