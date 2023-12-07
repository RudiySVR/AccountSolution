using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSolution.FromAccountClassLibrary.Entities
{
    public class ShortPrice
    {
        public ShortPrice() { }

        public ShortPrice(int stockpricegroupeid,
                     string stockgroupe,
                     string valueforcount,
                     double baseprice,
                     double basepdv,
                     double second,
                     double secondpdv,
                     double third,
                     double thirdpdv
                    )
        {
            this.StockPriceGroupeID = stockpricegroupeid;
            this.StockGroupe = stockgroupe;
            this.ValueForCount = valueforcount;
            this.Base = baseprice;
            this.BasePDV = basepdv;
            this.Second = second;
            this.SecondPDV = secondpdv;
            this.Third = third;
            this.ThirdPDV = thirdpdv;
        }

        public int StockPriceGroupeID { get; set; }
        public string StockGroupe { get; set; }
        public string ValueForCount { get; set; }
        public double Base { get; set; }
        public double BasePDV { get; set; }
        public double Second { get; set; }
        public double SecondPDV { get; set; }
        public double Third { get; set; }
        public double ThirdPDV { get; set; }
    }
}
