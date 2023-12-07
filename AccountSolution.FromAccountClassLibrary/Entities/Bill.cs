using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSolution.FromAccountClassLibrary.Entities
{
    public class Bill
    {
        //public Bill() { }

        //public Bill(
        //  int orderID, string userID, string deliveryName, double totalPrice, DateTime dateCreated, string orderGuid
        //string OrderID,
        //string UserID,
        //string BasketID,
        //DateTime AddedDate,
        //string AddedBy,
        //string StatusID,
        //string ShippingMethod,
        //int SubTotal,
        //string Shipping,
        //string ShippingFirstName,
        //string ShippingLastName,
        //string ShippingStreet,
        //string ShippingPostalCode,
        //string ShippingCity,
        //string ShippingState,
        //string ShippingCountry,
        //string CustomerEmail,
        //string CustomerPhone,
        //string CustomerFax,
        //string ShippedDate,
        //string TransactionID,
        //string TrackingID
        //   )
        //{
        //    this.OrderID = orderID;
        //    this.UserID = userID;
        //    this.DeliveryName = deliveryName;
        //    this.TotalPrice = totalPrice;
        //    this.DateCreated = dateCreated;
        //    this.OrderGuid = orderGuid;
        //}


        public int ID { get; set; }
        [Display(Name = "номер заказа")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public string OrderGuid { get; set; }
        //[Display(Name = "Время заказа")]
        public DateTime DateDoc { get; set; }
        //[Display(Name = "Клиент")]
        public string UserID { get; set; }
        //[Display(Name = "Получатель")]
        public string DeliveryName { get; set; }
        //[Display(Name = "Адрес доставки")]
        //public Address DeliveryAddress { get; set; }
        //[Display(Name = "Общая ст-ть")]
        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:c}")]
        public double TotalPrice { get; set; }
        //[Display(Name = "Время заказа")]
        public DateTime DateCreated { get; set; }
        public List<BillLine> OrderLines { get; set; }

        public Bill()
        {
            OrderLines = new List<BillLine>();
        }

    }
}
