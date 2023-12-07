using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSolution.FromAccountClassLibrary.Entities
{
    public class BillLine
    {
        public int ID { get; set; } = 0;
        public string OrderGuid { get; set; }
        public string Stock { get; set; }
        public string StockCounter { get; set; }
        public double Quatity { get; set; }
        //public int? TeamId { get; set; }
        public Bill Bill { get; set; }
        //public DateTime AddedDate { get; set; } = DateTime.Now;

        //public string AddedBy { get; set; } = "";

        //public int StatusID { get; set; } = 0;

        //public string StatusTitle { get; set; } = "";

        //public string ShippingMethod { get; set; } = "";

        //public decimal SubTotal { get; set; } = 0.0m;

        //public decimal Shipping { get; set; } = 0.0m;

        //public string ShippingFirstName { get; set; } = "";

        //public string ShippingLastName { get; set; } = "";

        //public string ShippingStreet { get; set; } = "";

        //public string ShippingPostalCode { get; set; } = "";

        //public string ShippingCity { get; set; } = "";

        //public string ShippingState { get; set; } = "";

        //public string ShippingCountry { get; set; } = "";

        //public string CustomerEmail { get; set; } = "";

        //public string CustomerPhone { get; set; } = "";

        //public string CustomerFax { get; set; } = "";

        //public string TransactionID { get; set; } = "";

        //public DateTime ShippedDate { get; set; } = DateTime.MinValue;

        //public string TrackingID { get; set; } = "";
    }
}
