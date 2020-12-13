using MegaDesk_Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDesk_Web.Models
{ 
    public class DeskQuote
    {
        public int DeskQuoteID { get; set; }
        public int DeskTopMaterialID { get; set; }
        public DesktopMaterial DesktopMaterial { get; set; }

        public const short BASE_DESK_COST = 200;
        public int Width { get; set; }

        public int Depth { get; set; }

        public int NumDrawers { get; set; }

        public int NumDesks { get; set; }
        public int ShippingID { get; set; }

        public string Name { get; set; }
        public Shipping Shipping { get; set; }

        private int _area;
        public int Area { get { _area = Width * Depth; return _area; } set { _area = value; } }

        private int _areaCost;
        public int AreaCost
        {
            get
            {
                if (Area <= 1000)
                    return 0;
                else
                {
                    _areaCost = Area - 1000;
                    return _areaCost;
                }

            }
            set
            {
                _areaCost = value;
            }
        }
        private int _numberofDrawersCost;
        public int NumberofDrawersCost
        {
            get
            {
                _numberofDrawersCost = NumDrawers * 50;
                return _numberofDrawersCost;
            }
            set
            {
                _numberofDrawersCost = value;
            }
        }

        private int _numDeskCost;

        public int NumDeskCost
        {
            get { _numDeskCost = NumDesks * BASE_DESK_COST; return _numDeskCost; }
            set { _numDeskCost = value; }
        }
        //private float _totalCost;
        //public float totalCost
        //{
        //    get
        //    {
        //        float totalBeforeDesks = //ShippingCost + NumberofDrawersCost + //D.MaterialCost
        //            + AreaCost;
        //        _totalCost = (totalBeforeDesks * NumDesks) + NumDeskCost;
        //        return _totalCost;
        //    }
        //    set
        //    {
        //        _totalCost = value;
        //    }
        //}

        //public decimal GetQuotePrice(MegaDesk_WebContext context)
        //{

        //}

        public static Dictionary<string, List<int>> GetRushOrder()
        {

            var priceFile = @"rushOrderPrices.txt";
            List<int> threeDayPrices = new List<int>();
            List<int> fiveDayPrices = new List<int>();
            List<int> sevenDayPrices = new List<int>();
            List<int> prices = new List<int>();


            //if (File.Exists(priceFile))
            //{
            //    using (StreamReader reader = new StreamReader(priceFile))
            //    {
            //        string text = reader.ReadToEnd();

            //        if (text.Length > 0)
            //        {

            //            prices = text.Split(',').Select(int.Parse).ToList();

            //            for (int i = 0; i < text.Length; i++)
            //            {
            //                prices.Add(text[i] - '0');
            //            }
            //        }

            //    }
            //}
            for (int i = 0; i < 3; i++)
            {

                threeDayPrices.Add(prices[i]);
            }

            for (int i = 3; i < 6; i++)
            {
                fiveDayPrices.Add(prices[i]);
            }

            for (int i = 6; i < 9; i++)
            {
                sevenDayPrices.Add(prices[i]);
            }

            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>()
            {
                {"3 Day", threeDayPrices },
                {"5 Day", fiveDayPrices },
                {"7 Day", sevenDayPrices }
            };
            return dict;
        }

    }
}
