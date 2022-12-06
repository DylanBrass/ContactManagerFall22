using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System.Collections.Generic;
using System.Windows;

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

            Contacts = db.GetContacts();

            foreach (Contact tempCon in Contacts)
            {
                this.ListContacts.Items.Add(new Contact { Id = tempCon.Id, FirstName = tempCon.FirstName, LastName = tempCon.LastName });
            }

            //this.ListContacts.Items.Add(db.GetContact(12));
        }
    }
}
