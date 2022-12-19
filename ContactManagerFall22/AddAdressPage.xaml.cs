using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for AddAdressPage.xaml
    /// </summary>
    public partial class AddAdressPage : Window
    {

       readonly DBManager dB = new DBManager();
        public AddAdressPage()
        {
            InitializeComponent();
        }

        private void AddAddressButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(AddressNumber.Text.ToString()) || String.IsNullOrEmpty(Street.Text) || (String.IsNullOrEmpty(AppartementNum.Text.ToString()) || String.IsNullOrEmpty(City.Text)))
            {
                this.Close();
            }
            else
            {
                Address addingAddress = new Address();

                var addressNumber = int.TryParse(AddressNumber.Text, out int number);
                addingAddress.AddressNumber = number;

                addingAddress.Street = Street.Text;

                var appNum = int.TryParse(AppartementNum.Text, out int appNumber);
                addingAddress.ApartementNum = appNumber;

                addingAddress.City = City.Text;
                addingAddress.Country = Country.Text;
                addingAddress.AreaCode = AreaCode.Text;


                dB.CreateAddress(addingAddress);
                this.Close();
            }
        }

        private void Window_closed(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}


