using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountSolution.FromAccountClassLibrary.MSAccessClient;
using AccountSolution.SqliteClassLibrary;

namespace AccountSolution.WindowsFormsApp
{
    public partial class ShortPrice : Form
    {
        AccessPriceProvider accessPriceProvider = new AccessPriceProvider();
        SqlitePriceProvider sqlitePriceProvider = new SqlitePriceProvider();
        BindingSource bindingSource = new BindingSource();
        public ShortPrice()
        {
            InitializeComponent();
            this.Load += ShortPrice_Load;
            this.dataGridView2.AutoGenerateColumns=true;
        }

        private void ShortPrice_Load(object sender, EventArgs e)
        {
            Console.WriteLine(Application.ExecutablePath.ToString());
            Console.WriteLine(Application.StartupPath.ToString());
            this.dataGridView1.DataSource = sqlitePriceProvider.GetPriceGroupAll();
            try
            {
                //AccessPriceProvider accessPriceProvider = new AccessPriceProvider();
                //this.dataGridView1.DataSource = accessPriceProvider.GetPriceGroupAll();
                //bindingSource.DataSource = accessPriceProvider.GetPriceGroupAll();
                //this.dataGridView1.DataSource = bindingSource;
                this.dataGridView2.DataSource = sqlitePriceProvider.GetPrice();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //throw new NotImplementedException();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    // You can start any process, HelloWorld is a do-nothing example.
                    //myProcess.StartInfo.FileName = "C:\\Sample\\Console\\AccSql.ConsoleApp.exe";
                    myProcess.StartInfo.FileName = Application.StartupPath.ToString() + "\\AccountSolution.ConsoleApp.exe";
                    myProcess.StartInfo.Arguments = "1";
                    //myProcess.StartInfo.Arguments=
                    //myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();
                    myProcess.WaitForExit();
                    // This code assumes the process you are starting will terminate itself. 
                    // Given that is is started without a window so you cannot terminate it 
                    // on the desktop, it must terminate itself or you can do it programmatically
                    // from this application using the Kill method.
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Process end");
            this.dataGridView1.DataSource = sqlitePriceProvider.GetPriceGroupAll();
            this.dataGridView2.DataSource = sqlitePriceProvider.GetPrice();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = sqlitePriceProvider.GetPriceGroupAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = sqlitePriceProvider.GetPrice();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = sqlitePriceProvider.GetShortPrice();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
