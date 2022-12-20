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
    /// Interaction logic for AddEmailPage.xaml
    /// </summary>
    public partial class AddEmailPage : Window
    {
        string radioCheck;
        readonly DBManager dB = new DBManager();
        readonly int Id;
        public AddEmailPage(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void AddEmailButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidEmail(Email.Text))
            {
                Email addingEmail = new Email();

                addingEmail.Contact_Id = Id;

                addingEmail.EmailAddress = Email.Text;

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
                dB.CreateEmail(addingEmail);
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

            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(str, regex, RegexOptions.IgnoreCase);

        }

    }
}
