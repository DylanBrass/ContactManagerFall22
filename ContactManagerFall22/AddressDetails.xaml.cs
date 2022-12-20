using ContactManagerFall22.DB.Entities;
using ContactManagerFall22.DB;
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
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for AddressDetails.xaml
    /// </summary>
    public partial class AddressDetails : Window
    {
        readonly int Id;
        string radioCheck;
        DBManager dbManager3 = new DBManager();
        public AddressDetails()
        {
            InitializeComponent();
        }

        private void Add_Address_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Address_btn_Click(object sender, RoutedEventArgs e)
        {

            List<Address> inputedAddress = dbManager3.GetAdresses(Id);
  
            AddAdressPage newAddrWindow = new AddAdressPage(Id);
            newAddrWindow.City.Text = inputedAddress[0].City; 
            newAddrWindow.Country.Text = inputedAddress[0].Country;
            newAddrWindow.ZipCode.Text = inputedAddress[0].ZipCode;
            newAddrWindow.Street.Text = inputedAddress[0].Street;
            newAddrWindow.AddressNumber.Text = inputedAddress[0].AddressNumber.ToString();
            newAddrWindow.AppartementNum.Text = inputedAddress[0].ApartementNum.ToString();
            newAddrWindow.ShowDialog();
            

        }

        private void Del_Address_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Done(object sender, RoutedEventArgs e)
        {

        }

        private void Address_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
