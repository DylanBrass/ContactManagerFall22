using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
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

            EditAddress editpage = new EditAddress(inputedAddress.Contact_Id);

            editpage.City.Text = inputedAddress.City.ToString();
            editpage.Country.Text = inputedAddress.Country.ToString();
            editpage.ZipCode.Text = inputedAddress.ZipCode.ToString();
            editpage.Street.Text = inputedAddress.Street.ToString();
            editpage.AddressNumber.Text = inputedAddress.AddressNumber.ToString();
            editpage.AppartementNum.Text = inputedAddress.ApartementNum.ToString();
            if (inputedAddress.Type == 'H')
            {
                editpage.Home.IsChecked = true;
            }
            else if (inputedAddress.Type == 'B')
            {
                editpage.Work.IsChecked = true;

            }
            else
            {
                editpage.Other.IsChecked = true;

            }
            editpage.ShowDialog();

            Window_Loaded();
        }

    }
}
