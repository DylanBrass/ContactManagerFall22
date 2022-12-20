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
using System.Xml.Linq;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for AddressDetails.xaml
    /// </summary>
    public partial class AddressDetails : Window
    {
        readonly int Id;
        DBManager dbManager3 = new DBManager();
        public AddressDetails(int id)
        {
            InitializeComponent();
            Window_Loaded(id);
        }

        private void Window_Loaded(int id)
        {
            Address address = dbManager3.GetAddress(id);
            StreetNumber.Content = "Street Number: " + address.AddressNumber.ToString();
            Street.Content = "Street: " + address.Street;
            ApartementNum.Content = "Apartment Number: " + address.ApartementNum.ToString();
            City.Content = "City: " + address.City;
            Country.Content = "Country: " + address.Country;
            AreaCode.Content = "Area Code: " + address.ZipCode;
            DateCreated.Content = "DateAdded: " + address.DateCreated.ToShortDateString();
            LastUpdated.Content = "DateUpdated: " + address.LastUpdated.ToShortDateString();


        }


        private void Edit_Address_btn_Click(object sender, RoutedEventArgs e)
        {

            List<Address> inputedAddress = dbManager3.GetAdresses(Id);
  
            AddAdressPage newAddrWindow = new AddAdressPage(Id);
            newAddrWindow.City.Text = inputedAddress[Id].City; 
            newAddrWindow.Country.Text = inputedAddress[Id].Country;
            newAddrWindow.ZipCode.Text = inputedAddress[Id].ZipCode;
            newAddrWindow.Street.Text = inputedAddress[Id].Street;
            newAddrWindow.AddressNumber.Text = inputedAddress[Id].AddressNumber.ToString();
            newAddrWindow.AppartementNum.Text = inputedAddress[Id].ApartementNum.ToString();
            newAddrWindow.ShowDialog();
            

        }

    }
}
