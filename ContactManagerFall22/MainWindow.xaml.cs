namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBManager db = new DBManager();

        // Shows the window.
        public MainWindow()
        {
            InitializeComponent();
            Window_Loaded();
        }

        private void Window_Loaded()
        {
            List<Contact> Contacts = new List<Contact>();
            List<Address> Addresses = new List<Address>();
            Contacts = db.GetContacts();
            ListContacts.ItemsSource = Contacts;


            //this.ListContacts.Items.Add(db.GetContact(12));
        }

        private void ContactsListItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Contact selectedContact = (Contact)ListContacts.SelectedItem;

            if (selectedContact != null)
            {
                DetailsPage newWindow = new DetailsPage(selectedContact.Id);
                newWindow.ShowDialog();
            }
        }

    }
}
