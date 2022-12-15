using ContactManagerFall22.DB.Entities;
using System;
using System.Data;
using System.Windows;
using System.Windows.Media;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public AddContact()
        {
            InitializeComponent();
        }
        public void AddContact_Button(object sender, RoutedEventArgs e)
        {
            //Contact addingContact = new Contact(FName.Text, LName.Text, email.Text, Salutation.Text, Nickname.Text, Birthday.Text,);
            Contact addingContact = new Contact();
            addingContact.FirstName = FName.Text;
            addingContact.LastName = LName.Text;
            addingContact.Nickname = Nickname.Text;
            addingContact.Email = email.Text;
            //string BDString = Birthday.Text;
            //if (BDString != null)
            //{
            //    addingContact.Birthday = DateTime.Parse(BDString);
            //}
            addingContact.Salutation = Salutation.Text;
            addingContact.Note = Note.Text;
            addingContact.Favourite = favourite.IsChecked;
            this.Close();

        }
    }
}
