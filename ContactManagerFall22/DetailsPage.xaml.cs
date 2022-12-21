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
        readonly int Id;
        DBManager dbManager = new DBManager();
        readonly CSVHandler csv = new CSVHandler();
        public DetailsPage(int id)
        {
            Id = id;
            InitializeComponent();
            Window_Loaded(id);
        }



        private void Window_Loaded(int id)
        {
            List<Address> Addresses = dbManager.GetAdresses(Id);
            AddressQuickView.ItemsSource = Addresses;

            dbManager = new DBManager();

            List<Phone> phones = dbManager.GetPhones(Id);
            PhoneQuickView.ItemsSource = phones;

            dbManager = new DBManager();

            List<Email> emails = dbManager.GetEmails(Id);
            EmailQuickView.ItemsSource = emails;
            Contact contact = dbManager.GetContact(id);

            Image image = dbManager.GetImage(contact.Id);
            Pfp.Source = image.Source;

            dbManager = new DBManager();
            Nickname.Content = "Nickname: " + contact.Nickname;
            LName.Content = "Last Name: " + contact.LastName;
            FName.Content = "First Name: " + contact.FirstName;
            Birthday.Content = "Birthday: " + contact.Birthday.ToLongDateString();
            Salutation.Content = "Salutation: " + contact.Salutation;
            DateAdded.Content = "DateAdded: " + contact.DateAdded.ToShortDateString();
            DateUpdated.Content = "DateUpdated: " + contact.DateUpdated.ToShortDateString();
            Note.Content = "Note: " + contact.Note;
            Favourite.Content = "Favourite: " + contact.Favourite;

        }



        private void AddressDetails_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Address selectedAddress = (Address)AddressQuickView.SelectedItem;

            if (selectedAddress != null)
            {
                AddressDetails newWindow = new AddressDetails(selectedAddress.Id);
                newWindow.Show();
                dbManager = new DBManager();

                List<Address> Addresses = dbManager.GetAdresses(Id);
                AddressQuickView.ItemsSource = Addresses;
            }



        }
        private void EmailDetailsPage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Email selectedEmail = (Email)EmailQuickView.SelectedItem;

            if (selectedEmail != null)
            {
                EmailDetails newWindow = new EmailDetails(selectedEmail.Id);
                newWindow.ShowDialog();
                dbManager = new DBManager();

                List<Email> emails = dbManager.GetEmails(Id);
                PhoneQuickView.ItemsSource = emails;
            }
        }

        private void PhoneDetails_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Phone selectedPhone = (Phone)PhoneQuickView.SelectedItem;

            if (selectedPhone != null)
            {
                PhoneDetails newWindow = new PhoneDetails(selectedPhone.Id);
                newWindow.ShowDialog();
                dbManager = new DBManager();

                List<Phone> Phones = dbManager.GetPhones(Id);
                PhoneQuickView.ItemsSource = Phones;
            }
        }

        private void New_Address_Click(object sender, RoutedEventArgs e)
        {
            AddAdressPage newAddressWindow = new AddAdressPage(Id);
            newAddressWindow.ShowDialog();
            dbManager = new DBManager();

            List<Address> Addresses = dbManager.GetAdresses(Id);
            AddressQuickView.ItemsSource = Addresses;
        }

        private void Phone_Click(object sender, RoutedEventArgs e)
        {
            PhoneDetails phoneDetailsWindow = new PhoneDetails(Id);
            phoneDetailsWindow.ShowDialog();


        }

        private void New_Phone_Click(object sender, RoutedEventArgs e)
        {
            AddPhoneNumber newPNWindow = new AddPhoneNumber(Id);
            newPNWindow.ShowDialog();
            dbManager = new DBManager();

            List<Phone> phones = dbManager.GetPhones(Id);
            PhoneQuickView.ItemsSource = phones;
        }

        private void New_Email_Click(object sender, RoutedEventArgs e)
        {
            AddEmailPage newEMWindow = new AddEmailPage(Id);
            newEMWindow.ShowDialog();
            dbManager = new DBManager();

            List<Email> emails = dbManager.GetEmails(Id);
            EmailQuickView.ItemsSource = emails;

        }


        private void Delete_Contact(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this contact?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                dbManager = new DBManager();
                dbManager.DeleteContact(Id);
                Window_Loaded(Id);
            }


        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void Import_Address(object sender, RoutedEventArgs e)
        {
            csv.ImportAddress(Id);
            dbManager = new DBManager();

            List<Address> Addresses = dbManager.GetAdresses(Id);
            AddressQuickView.ItemsSource = Addresses;
        }

        private void Export_Address(object sender, RoutedEventArgs e)
        {
            if (dbManager.GetAdresses(Id).Count > 0)
                csv.ExportAddress(Id);
        }

        private void Import_Phone(object sender, RoutedEventArgs e)
        {
            csv.ImportPhone(Id);
            dbManager = new DBManager();

            List<Phone> phones = dbManager.GetPhones(Id);
            PhoneQuickView.ItemsSource = phones;
        }

        private void Export_Phone(object sender, RoutedEventArgs e)
        {
            if (dbManager.GetPhones(Id).Count > 0)
                csv.ExportPhone(Id);
        }

        private void Import_Email(object sender, RoutedEventArgs e)
        {
            csv.ImportEmail(Id);
            dbManager = new DBManager();

            List<Email> emails = dbManager.GetEmails(Id);
            EmailQuickView.ItemsSource = emails;
        }

        private void Export_Email(object sender, RoutedEventArgs e)
        {
            if (dbManager.GetEmails(Id).Count > 0)
                csv.ExportEmail(Id);
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {

            Window_Loaded(Id);

        }

        private void Add_Image(object sender, RoutedEventArgs e)
        {
            SelectingImagePage sp = new SelectingImagePage(Id);
            sp.Show();
            Window_Loaded(Id);
        }
    }
}
