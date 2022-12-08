using ContactManagerFall22.DB.Entities;
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
using System.Windows.Shapes;

using ContactManagerFall22.DB;


namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for AddAddressPage.xaml
    /// </summary>
    public partial class AddAddressPage : Window
    {
        DBManager db = new DBManager();
        public AddAddressPage()
        {
            InitializeComponent();
            Window_Loaded();
        }

        private void Window_Loaded()
        {
            db.GetAdresses(8);

        }

        private void AddressListItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Add_Address_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Address_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Address_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Done(object sender, RoutedEventArgs e)
        {

        }

    }
}
