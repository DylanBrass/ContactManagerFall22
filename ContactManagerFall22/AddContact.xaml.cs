using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        readonly DBManager dB = new DBManager();
        public AddContact()
        {
            InitializeComponent();
        }
        public void AddContact_Button(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(FName.Text) || String.IsNullOrEmpty(LName.Text) || String.IsNullOrEmpty(BirthDate.Text))
            {
                MessageBox.Show("Not all required fields were filled !", "Empty fields");
            }
            else
            {

                Contact addingContact = new Contact
                {
                    FirstName = FName.Text,
                    LastName = LName.Text,
                    Nickname = Nickname.Text,
                    Birthday = Convert.ToDateTime(BirthDate.Text),
                    Salutation = Salutation.Text,
                    Note = Note.Text,
                    Favourite = favourite.IsChecked
                };
                if (IsValidNoNumbers(FName.Text) && IsValidNoNumbers(LName.Text))
                {
                    MessageBox.Show("Contact Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dB.CreateContact(addingContact);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Numbers in First or Last name !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }


        private static bool IsValidNoNumbers(string str)
        {
            str = str.Replace(" ", "");
            str = str.Replace("-", "");

            string regex = @"[a-z]+$";

            return Regex.IsMatch(str, regex, RegexOptions.IgnoreCase);
        }


    }
}
