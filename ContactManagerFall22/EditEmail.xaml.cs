using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using RadioButton = System.Windows.Controls.RadioButton;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for EditEmail.xaml
    /// </summary>
    public partial class EditEmail : Window
    {
        string radioCheck;
        readonly DBManager dB = new DBManager();
        readonly int Id;
        public EditEmail(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void AddEmailButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidEmail(Email.Text))
            {
                Email addingEmail = new Email
                {
                    Contact_Id = Id,

                    EmailAddress = Email.Text
                };

                switch (radioCheck)
                {
                    case "Work":
                        addingEmail.Type = 'B';
                        break;
                    case "Home":
                        addingEmail.Type = 'H';
                        break;
                    default:
                        addingEmail.Type = 'O';
                        break;
                }
                dB.UpdateEmail(addingEmail);
                this.Close();
            }
            else
                MessageBox.Show("Improper Format", "Email does not follow the correct Format !", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Warning);

        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                radioCheck = ck.Content.ToString();
        }


        private bool IsValidEmail(string str)
        {

            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|ca|edu)$";

            return Regex.IsMatch(str, regex, RegexOptions.IgnoreCase);

        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
