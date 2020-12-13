using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MegaDesk_Web.Models
{
    public class Desk
    {
        public int DeskID { get; set; }
        private int material;
        //public const short MIN_WIDTH = 24;
        //public const short MAX_WIDTH = 96;
        //public const short MIN_DEPTH = 12;
        //public const short MAX_DEPTH = 48;
        //public const short MAX_DESK_DRAWERS = 7;
        //public const short LAMINATE_COST = 100;
        //public const short OAK_COST = 200;
        //public const short ROSEWOOD_COST = 300;
        //public const short PINE_COST = 50;
        //public const short VENEER_COST = 125;

        public int DesktopMaterialID;
        public int Width { get; set; }
        public int Depth { get; set; }

        public DesktopMaterial DesktopMaterial;

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

        public int NumberofDrawers { get; set; }

        private int _numberofDrawersCost;
        public int NumberofDrawersCost
        {
            get
            {
                _numberofDrawersCost = NumberofDrawers * 50;
                return _numberofDrawersCost;
            }
            set
            {
                _numberofDrawersCost = value;
            }
        }

        //public int MaterialCost
        //{
        //    //get
        //    //{

        //    //    material = (int)SurfaceMaterial;
        //    //    switch (material)
        //    //    {
        //    //        case 0:
        //    //            return LAMINATE_COST;
        //    //            break;
        //    //        case 1:
        //    //            return OAK_COST;
        //    //            break;
        //    //        case 2:
        //    //            return ROSEWOOD_COST;
        //    //        case 3:
        //    //            return VENEER_COST;
        //    //        case 4:
        //    //            return PINE_COST;
        //    //    }
        //    //    return _materialCost;
        //    //}
        //    //set
        //    //{
        //    //    _materialCost = value;
        //    //}
        //}
    }
}
