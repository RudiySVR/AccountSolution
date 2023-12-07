using AccountSolution.ExIm77;
using AccountSolution.FromAccountClassLibrary.Entities;
using AccountSolution.MsSqlClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BillContext db = new BillContext())
            {
                // создаем два объекта User
                Bill user1 = new Bill
                {
                    OrderID = 6,
                    DeliveryName = "Tom",
                    TotalPrice = 33,
                    OrderGuid = "jklhjklh",
                    UserID = "465",
                    DateDoc = DateTime.Now,
                    DateCreated = DateTime.Now
                };
                Bill user2 = new Bill
                {
                    OrderID = 7,
                    DeliveryName = "Sam",
                    TotalPrice = 26,
                    OrderGuid = "jklhjklh",
                    UserID = "465",
                    DateDoc = DateTime.Now,
                    DateCreated = DateTime.Now
                };

                try
                {
                    // добавляем их в бд
                    db.Bills.Add(user1);
                    db.Bills.Add(user2);
                    db.SaveChanges();
                    Console.WriteLine("Объекты успешно сохранены");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //throw;
                }
                // получаем объекты из бд и выводим на консоль
                var users = db.Bills;
                Console.WriteLine("Список объектов:");
                foreach (Bill u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.ID, u.DeliveryName, u.TotalPrice);
                }
            }
            Console.ReadKey();
        }

        public static void Trade()
        {
            try
            {
                Trade trade = new Trade();
                //Console.ReadKey();
                if (trade.blGood)
                {
                    //exIm77.BillMove();
                    trade.BillMove("16.09.2019", "21.09.2019");
                }
                else
                {
                    Console.WriteLine("Not open!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
