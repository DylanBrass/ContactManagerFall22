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
                string stringBD = Convert.ToString(BirthDate.Text);

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
                dB.CreateContact(addingContact);
                if (IsValidFirst(FName.Text) && IsValidLast(LName.Text))
                    MessageBox.Show("Numbers in First or last name !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    this.Close();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
        private static bool IsValidFirst(string first)
        {
            string regex = @"[a-z]+";

            return Regex.IsMatch(first, regex, RegexOptions.IgnoreCase);
        }
        private static bool IsValidLast(string last)
        {
            string regex = @"[a-z]+";

            return Regex.IsMatch(last, regex, RegexOptions.IgnoreCase);
        }
    }
}
