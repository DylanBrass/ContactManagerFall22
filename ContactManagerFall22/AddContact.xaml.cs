using ContactManagerFall22.DB.Entities;
using System.Windows;

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
            addingContact.Favourite = favourite.IsChecked;

        }

        private void FName_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (FName.Text == "First Name")
            {
                FName.Text = "";
            }
        }

        private void FName_LostMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (FName.Text == "")
            {
                FName.Text = "First";
            }
        }
    }
}
