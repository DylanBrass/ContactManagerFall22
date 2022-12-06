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
        }
        private void Window_Loaded(int id)
        {
            Contact contact = new Contact();

            TextBox Fname = new TextBox();
            TextBox Lname = new TextBox();
            TextBox email = new TextBox();
            TextBox active = new TextBox();

            Fname.Text = "First Name: " + contact.FirstName;
            Lname.Text = "First Name: " + contact.LastName;
            email.Text = "Email: " + contact.Email;
            active.Text = "First Name: " + contact.Active;


            contact = dbManager.GetContact(id);


        }

    }
}
