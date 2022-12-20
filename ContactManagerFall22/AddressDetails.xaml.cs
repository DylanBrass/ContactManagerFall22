using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for AddressDetails.xaml
    /// </summary>
    public partial class AddressDetails : Window
    {
        readonly int Id;
        readonly DBManager dbManager3 = new DBManager();
        public AddressDetails(int id)
        {
            Id = id;
            InitializeComponent();
            Window_Loaded();
        }

        private void Window_Loaded()
        {
            Address address = dbManager3.GetAddress(Id);
            StreetNumber.Content = "Street Number: " + address.AddressNumber.ToString();
            Street.Content = "Street: " + address.Street;
            ApartementNum.Content = "Apartment Number: " + address.ApartementNum.ToString();
            City.Content = "City: " + address.City;
            Country.Content = "Country: " + address.Country;
            AreaCode.Content = "Area Code: " + address.ZipCode;
            DateCreated.Content = "DateAdded: " + address.DateCreated.ToShortDateString();
            LastUpdated.Content = "DateUpdated: " + address.LastUpdated.ToShortDateString();
        }

        private void Delete_Address(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Address?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                dbManager3.DeleteAddress(Id);
                this.Close();
            }


        }


        private void Edit_Address_btn_Click(object sender, RoutedEventArgs e)
        {
            Address inputedAddress = dbManager3.GetAddress(Id);

            AddAdressPage newAddrWindow = new AddAdressPage(Id);

            newAddrWindow.City.Text = inputedAddress.City.ToString();
            newAddrWindow.Country.Text = inputedAddress.Country.ToString();
            newAddrWindow.ZipCode.Text = inputedAddress.ZipCode.ToString();
            newAddrWindow.Street.Text = inputedAddress.Street.ToString();
            newAddrWindow.AddressNumber.Text = inputedAddress.AddressNumber.ToString();
            newAddrWindow.AppartementNum.Text = inputedAddress.ApartementNum.ToString();
            newAddrWindow.ShowDialog();
            

        }

    }
}
