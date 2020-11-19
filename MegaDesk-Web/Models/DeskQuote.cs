using MegaDesk_Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDesk_Web.Models
{
    public enum DeliveryType
    {
        Rush3Days,
        Rush5Days,
        Rush7Days,
        NoRush
    }

    public class DeskQuote
    {
        public int DeskQuoteID { get; set; }
        public const short BASE_DESK_COST = 200;
        public int DeskID { get; set; }
        public int ShippingID { get; set; }
        public Desk D { get; set; }

        public string Name { get; set; }
        public string Shipping { get; set; }
        public int NumDesks { get; set; }

        private int _numDeskCost;



        private float _shippingCost;
        public float ShippingCost
        {

            get
            {
                Dictionary<string, List<int>> prices = GetRushOrder();

                if (D.Area < 1000)
                {
                    _shippingCost = prices[Shipping][0];
                }
                else if (D.Area >= 1000 && D.Area <= 2000)
                {
                    _shippingCost = prices[Shipping][1];
                }

                else
                {
                    _shippingCost = prices[Shipping][2];
                }

                return _shippingCost;
            }
            set { _shippingCost = value; }
        }
        public int NumDeskCost
        {
            get { _numDeskCost = NumDesks * BASE_DESK_COST; return _numDeskCost; }
            set { _numDeskCost = value; }
        }
        private float _totalCost;
        public float totalCost
        {
            get
            {
                float totalBeforeDesks = ShippingCost + D.NumberofDrawersCost + //D.MaterialCost
                    + D.AreaCost;
                _totalCost = (totalBeforeDesks * NumDesks) + NumDeskCost;
                return _totalCost;
            }
            set
            {
                _totalCost = value;
            }
        }

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
