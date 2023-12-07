using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountSolution.FromAccountClassLibrary.MSAccessClient;
using AccountSolution.SqliteClassLibrary;

namespace AccountSolution.WindowsFormsApp
{
    public partial class Price : Form
    {
        AccessPriceProvider accessPriceProvider = new AccessPriceProvider();
        SqlitePriceProvider sqlitePriceProvider = new SqlitePriceProvider();
        public Price()
        {
            InitializeComponent();
            this.Load += Price_Load;
        }

        private void Price_Load(object sender, EventArgs e)
        {
            try
            {
                var CurrentPrice = sqlitePriceProvider.GetPrice();
                //var CurrentPrice = sqlitePriceProvider.GetPrice().Join(sqlitePriceProvider.GetPriceGroup(),
                //    p=>p.NumbGroup,
                //    x=>x.GroupID,
                //    (p) => new { p});
                var CurrentShortPrice = sqlitePriceProvider.GetShortPrice();
                //var result = CurrentPrice.Join(CurrentShortPrice, // второй набор
                //    p => p.StockPriceGroupeID, // свойство-селектор объекта из первого набора
                //    t => t.StockPriceGroupeID, // свойство-селектор объекта из второго набора
                //    (p, t) => new { Name = p.Stock, Team = p.ValueForCount, Country = t.BasePDV }); // результат
                var result =
                  from itemA in CurrentPrice//.Outer()
                  join itemB in CurrentShortPrice
                  on itemA.StockPriceGroupeID equals itemB.StockPriceGroupeID
                  select new { itemA.Stock, itemA.ValueForCount, itemA.CountForPack, itemB.BasePDV };
                Console.WriteLine("===========================");
                foreach (var item in result)
                    Console.WriteLine("{0} - {1} ({2})", item.Stock,item.ValueForCount, item.BasePDV);  //var next = accessPriceProvider.GetPrice().Select(x=>x.Stock);
                Console.WriteLine("===========================");
                //this.dataGridView1.DataSource = accessPriceProvider.GetPrice();
                //this.dataGridView1.DataSource = sqlitePriceProvider.GetPrice();
                this.dataGridView1.DataSource = result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Next");
        }
    }
}
