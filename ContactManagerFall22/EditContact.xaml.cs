using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for EditContact.xaml
    /// </summary>
    public partial class EditContact : Window
    {
        int Id;
        readonly DBManager dB = new DBManager();

        public EditContact(int id)
        {
            InitializeComponent();
            Id = id;
        }
        public void AddContact_Button(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(FName.Text) || String.IsNullOrEmpty(LName.Text) || String.IsNullOrEmpty(BirthDate.Text))
            {
                MessageBox.Show("Not all required fields were filled !", "Empty fields");
            }
            else
            {

                Contact updatedContact = new Contact
                {
                    Id = Id,
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
                    dB.UpdateContact(updatedContact);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Numbers in First or Last name !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

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
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
