using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSolution.FromAccountClassLibrary.Entities
{
    public class Price
    {
        public Price() { }

        public Price(string stockcounter,
                     string numbgroup,
                     int stockpricegroupeid,
                     string stock,
                     string fullname,
                     double countforpack,
                     string valueforcount,
                     //string character,
                     double priceforcount)
        {
            this.StockCounter = stockcounter;
            this.NumbGroup = numbgroup;
            this.StockPriceGroupeID = stockpricegroupeid;
            this.Stock = stock;
            this.FullName = fullname;
            this.CountForPack = countforpack;
            this.ValueForCount = valueforcount;
            //this.Character = character;
            this.PriceForCount = priceforcount;
        }
        public string StockCounter { get; set; }
        public string NumbGroup { get; set; }
        public int StockPriceGroupeID { get; set; }
        public string Stock { get; set; }
        public string FullName { get; set; }
        public double CountForPack { get; set; }
        public string ValueForCount { get; set; }
        public string Character { get; set; }
        public double PriceForCount { get; set; }
        //public string OldID { get; set; }
        //public string BarCode { get; set; }
        //public string BarCodeString { get; set; }
        //public string NumbMacGroup { get; set; }
        //public string GroupNameRus { get; set; }
        //public string GroupNameEng { get; set; }
        //public bool Internet { get; set; }
        //public string Logo { get; set; }
        //public double Теорвес { get; set; }
        //public string NumbValueForCount { get; set; }
        //public string PDV_ID { get; set; }
        //public string AccStockID { get; set; }
        //public string AccStockIDZatr { get; set; }
        //public string TMC_Numb { get; set; }
        //public string TMC_Name { get; set; }
        //public string CostID { get; set; }
        //public string CostName { get; set; }
        //public string KindWorkID { get; set; }
        //public string KindWorkName { get; set; }
        //public string NormID { get; set; }
        //public string Артикул { get; set; }
        //public string CountryID { get; set; }
        //public string StockUkr { get; set; }
        //public string NDS { get; set; }
        //public string Для кассы { get; set; }
        //public string Print { get; set; }
        //public string StoreNumb { get; set; }
        //public string Rest { get; set; }
        //public string OutPut { get; set; }
        //public string KodBuh { get; set; }
        //public string blIsDel { get; set; }
        //public string ReportID { get; set; }
        //public string WidthPoll { get; set; }
        //public string AutoKoef { get; set; }
        //public string CutKoef { get; set; }
    }
}
