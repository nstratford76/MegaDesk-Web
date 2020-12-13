using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDesk_Web.Models
{
    public class Shipping
    {
        public String RushOrder { get; set; }

        public List<int> RushPrices { get; set; }
        // List<int> fiveDay = new List<int>() { 40, 50, 60 };
        // List<int> sevenDay = new List<int>() { 30, 35, 40 };
    }
}
