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
    /// Interaction logic for AddAdressPage.xaml
    /// </summary>
    public partial class AddAdressPage : Window
    {
        string radioCheck;
        readonly DBManager dB = new DBManager();
        readonly int Id;
        public AddAdressPage(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void AddAddressButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(AddressNumber.Text)
                || String.IsNullOrEmpty(Street.Text)
                || String.IsNullOrEmpty(City.Text)
                || String.IsNullOrEmpty(Country.Text)
                || String.IsNullOrEmpty(ZipCode.Text)
                || String.IsNullOrEmpty(radioCheck))
            {
                MessageBox.Show("Not all required fields were filled !", "Empty fields");
            }
            else
            {
                Address addingAddress = new Address
                {
                    Contact_Id = Id
                };
                _ = int.TryParse(AddressNumber.Text, out int number);
                addingAddress.AddressNumber = number;

                addingAddress.Street = Street.Text;

                if (AppartementNum.Text == null || AppartementNum.Text == "")
                {
                    addingAddress.ApartementNum = 0;

                }
                else
                    addingAddress.ApartementNum = Convert.ToInt32(AppartementNum.Text);

                addingAddress.City = City.Text;
                addingAddress.Country = Country.Text;
                addingAddress.ZipCode = ZipCode.Text;
                switch (radioCheck)
                {
                    case "Work":
                        addingAddress.Type = 'B';
                        break;
                    case "Home":
                        addingAddress.Type = 'H';
                        break;
                    default:
                        addingAddress.Type = 'O';
                        break;
                }
                if (IsValidZipCode(ZipCode.Text))
                {
                    if (IsValidNoNumbers(Street.Text) && IsValidNoNumbers(City.Text) && IsValidNoNumbers(Country.Text))
                    {
                        if (IsValidOnlyNumbers(AddressNumber.Text) && IsValidOnlyNumbers(addingAddress.ApartementNum.ToString()))
                        {
                            dB.CreateAddress(addingAddress);

                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("Address Number can't contain letters !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Numbers in fields !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Invalid Zip code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private static bool IsValidNoNumbers(string str)
        {
            str = str.Replace(" ", "");

            string regex = @"[a-z]+$";

            return Regex.IsMatch(str, regex, RegexOptions.IgnoreCase);
        }
        private static bool IsValidOnlyNumbers(string str)
        {
            string regex = @"^\d+$";

            return Regex.IsMatch(str, regex, RegexOptions.IgnoreCase);
        }
        private static bool IsValidZipCode(string str)
        {

            string regex = @"(^\d{5}(-\d{4})?$)|(^[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]{1}\d{1}[ABCEGHJKLMNPRSTVWXYZabceghjklmnprstv‌​xy]{1} *\d{1}[ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvxy]{1}\d{1}$)";

            return Regex.IsMatch(str, regex, RegexOptions.IgnoreCase);

        }
    }
}



