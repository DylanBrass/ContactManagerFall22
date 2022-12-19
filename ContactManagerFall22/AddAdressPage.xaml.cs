using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System;
using System.Windows;
using System.Windows.Controls;

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

            Address addingAddress = new Address();

            addingAddress.Contact_Id = Id;
            bool addressNumber = int.TryParse(AddressNumber.Text, out int number);
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
            addingAddress.AreaCode = AreaCode.Text;
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

            dB.CreateAddress(addingAddress);
            this.Close();

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
    }
}


