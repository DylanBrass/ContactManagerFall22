using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for PhoneDetails.xaml
    /// </summary>
    public partial class PhoneDetails : Window
    {
        readonly int Id;
        string radioCheck;
        readonly DBManager dbManager2 = new DBManager();
        public PhoneDetails(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void Phone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_PhoneNum_btn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoneNumber newPhone = new AddPhoneNumber(Id);
            newPhone.ShowDialog();
        }

        private void Edit_PhoneNum(object sender, RoutedEventArgs e)
        {
            List<Phone> phones = dbManager2.GetPhones(Id);

            AddPhoneNumber newPNWindow = new AddPhoneNumber(Id);
            newPNWindow.PhoneNumber.Text = phones[0].PhoneNumber;
            newPNWindow.ShowDialog();
        }

    }
}
