using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ContactManagerFall22
{    /// <summary>
     /// Interaction logic for DetailsPage.xaml
     /// </summary>
    public partial class DetailsPage : Window
    {
        DBManager dbManager = new DBManager();
        public DetailsPage(int id)
        {
            InitializeComponent();
            Window_Loaded(id);
            Address_Window_Loaded(id);
        }

        private void Address_Window_Loaded(int id)
        {
            List<Address> Addresses = new List<Address>();
            Addresses = dbManager.GetAdresses(id);
            AddressQuickView.ItemsSource = Addresses;
        }

        private void Window_Loaded(int id)
        {
            Contact contact = new Contact();
            contact = dbManager.GetContact(id);

            Nickname.Content = "Nickname: " + contact.Nickname;
            LName.Content = "Last Name: " + contact.LastName;
            FName.Content = "First Name: " + contact.FirstName;
            Birthday.Content = "Birthday: " + contact.Birthday.ToShortDateString();
            Salutation.Content = "Salutation: " + contact.Salutation;
            DateAdded.Content = "DateAdded: " + contact.DateAdded.ToShortDateString();
            DateUpdated.Content = "DateUpdated: " + contact.DateUpdated.ToShortDateString();
            Note.Content = "Note: " + contact.Note;
            Favourite.Content = "Favourite: " + contact.Favourite;
        }

        private void AddressListItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Address_Click(object sender, RoutedEventArgs e)
        {
            AddressDetails newWindow = new AddressDetails();
            newWindow.ShowDialog();
        }
    }
}
