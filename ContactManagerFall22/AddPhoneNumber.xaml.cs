using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using RadioButton = System.Windows.Controls.RadioButton;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for AddPhoneNumber.xaml
    /// </summary>
    public partial class AddPhoneNumber : Window
    {
        string radioCheck;
        readonly DBManager dB = new DBManager();
        readonly int Id;

        public AddPhoneNumber(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void AddPhoneButton_Click(object sender, RoutedEventArgs e)
        {

            Phone addingPhone = new Phone();

            addingPhone.Contact_Id = Id;
            if (IsValidPhone(PhoneNumber.Text))
            {
                addingPhone.PhoneNumber = PhoneNumber.Text;

                switch (radioCheck)
                {
                    case "Work":
                        addingPhone.Type = 'B';
                        break;
                    case "Home":
                        addingPhone.Type = 'H';
                        break;
                    default:
                        addingPhone.Type = 'O';
                        break;
                }

                dB.CreatePhone(addingPhone);
                this.Close();
            }
            else
            {
                MessageBox.Show("Improper Format", "Phone number does not follow the correct Format !", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Warning);
            }
        }

        private void Window_closed(object sender, EventArgs e)
        {
            DetailsPage DP = new DetailsPage(Id);
            DP.Show();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                radioCheck = ck.Content.ToString();
        }


        public bool IsValidPhone(string str)
        {


            string regex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

            return Regex.IsMatch(str, regex, RegexOptions.IgnoreCase);


        }
    }
}