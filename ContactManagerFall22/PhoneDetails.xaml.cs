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
        DBManager dbManager3 = new DBManager();
        public PhoneDetails(int id)
        {
            Id = id;
            InitializeComponent();
            Window_Loaded();
        }

        private void Window_Loaded()
        {
            Phone phone = dbManager3.GetPhone(Id);



        }

        private void Delete_Address(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Address?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                dbManager3.DeleteAddress(Id);
                this.Close();
            }


        }

        private void Delete_Phone(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Phone(object sender, RoutedEventArgs e)
        {

        }
    }
}
