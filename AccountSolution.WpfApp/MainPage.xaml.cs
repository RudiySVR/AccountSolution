using AccountSolution.SqliteClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountSolution.WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        SqlitePriceProvider sqlitePriceProvider = new SqlitePriceProvider();

        public MainPage()
        {
            InitializeComponent();
            dataGrid.ItemsSource = sqlitePriceProvider.GetPrice();
        }

        void favoritesMenu_Click(object sender, RoutedEventArgs e)
        {
            //string folder = (treeView.SelectedItem as TreeViewItem).Tag as string;
            //if (favoritesMenu.Header as string == "Add Current Folder to Fa_vorites")
            //{
            //    AddFavorite(folder);
            //    favoritesMenu.Header = "Remove Current Folder from Fa_vorites";
            //}
            //else
            //{
            //    RemoveFavorite(folder);
            //    favoritesMenu.Header = "Add Current Folder to Fa_vorites";
            //}
        }

        void deleteMenu_Click(object sender, RoutedEventArgs e)
        {
        }

        void renameMenu_Click(object sender, RoutedEventArgs e) { }

        void refreshMenu_Click(object sender, RoutedEventArgs e) { }

        void exitMenu_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void fixMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void printMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
