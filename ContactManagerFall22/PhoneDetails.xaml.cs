using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System.Windows;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for PhoneDetails.xaml
    /// </summary>
    public partial class PhoneDetails : Window
    {
        readonly int Id;
        readonly DBManager dbManager3 = new DBManager();
        public PhoneDetails(int id)
        {
            Id = id;
            InitializeComponent();
            Window_Loaded();
        }

        private void Window_Loaded()
        {
            Phone phone = dbManager3.GetPhone(Id);

            PhoneNumber.Content = "Phone Number: " + phone.PhoneNumber.ToString();
            Type.Content = "Type: " + phone.Type;
            Description.Content = "Description: " + phone.Desc;
            DateCreated.Content = "DateAdded: " + phone.DateCreated.ToShortDateString();
            LastUpdated.Content = "DateUpdated: " + phone.LastUpdated.ToShortDateString();

        }

        private void Delete_Phone(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Address?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                dbManager3.DeletePhone(Id);
                this.Close();
            }


        }

        private void Edit_Phone(object sender, RoutedEventArgs e)
        {
            Phone inputedPhone = dbManager3.GetPhone(Id);

            EditAddress editpage = new EditAddress(inputedAddress.Contact_Id);

            editpage = inputedPhone.City.ToString();
            editpage.Country.Text = inputedPhone.Country.ToString();
            editpage.ZipCode.Text = inputedPhone.ZipCode.ToString();
            editpage.Street.Text = inputedPhone.Street.ToString();
            editpage.AddressNumber.Text = inputedPhone.AddressNumber.ToString();
            editpage.AppartementNum.Text = inputedPhone.ApartementNum.ToString();
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
