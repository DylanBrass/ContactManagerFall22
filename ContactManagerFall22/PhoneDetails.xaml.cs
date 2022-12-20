﻿using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System.Collections.Generic;
using System.Net;
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

            PhoneNumber.Content = "Phone Number: " + phone.PhoneNumber.ToString();
            Type.Content = "Type: " + phone.Type;
            Description.Content = "Description: " + phone.Desc;
            DateCreated.Content = "DateAdded: " + phone.DateCreated.ToShortDateString();
            LastUpdated.Content = "DateUpdated: " + phone .LastUpdated.ToShortDateString();

        }

        private void Delete_Phone(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Address?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                dbManager3.DeletePhone(Id);
                this.Close();
            }


        }
    }
}
