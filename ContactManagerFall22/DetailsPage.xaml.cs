using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System.Collections.Generic;
using System.Windows;
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
        }
        private void Window_Loaded(int id)
        {
            Contact contact = new Contact();
            contact = dbManager.GetContact(id);
            ContactsListItems.Items.Add(contact);


            //this.ListContacts.Items.Add(db.GetContact(12));
        }

    }
}
