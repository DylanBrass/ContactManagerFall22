﻿using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ContactManagerFall22
{    /// <summary>
     /// Interaction logic for DetailsPage.xaml
     /// </summary>
    public partial class DetailsPage : Window
    {
        readonly int Id;
        DBManager dbManager = new DBManager();
        public DetailsPage(int id)
        {
            Id = id;
            InitializeComponent();
            Window_Loaded(id);
            Address_Window_Loaded(id);
        }

        private void Address_Window_Loaded(int id)
        {
            List<Address> Addresses = dbManager.GetAdresses(id);
            AddressQuickView.ItemsSource = Addresses;

            dbManager = new DBManager();

            List<Phone> phones = dbManager.GetPhones(id);
            PhoneQuickView.ItemsSource = phones;

            dbManager = new DBManager();

            List<Email> emails = dbManager.GetEmails(id);
            EmailQuickView.ItemsSource = emails;
        }

        private void Window_Loaded(int id)
        {
            Contact contact = dbManager.GetContact(id);

            Nickname.Content = "Nickname: " + contact.Nickname;
            LName.Content = "Last Name: " + contact.LastName;
            FName.Content = "First Name: " + contact.FirstName;
            Birthday.Content = "Birthday: " + contact.Birthday.ToLongDateString();
            Salutation.Content = "Salutation: " + contact.Salutation;
            DateAdded.Content = "DateAdded: " + contact.DateAdded.ToShortDateString();
            DateUpdated.Content = "DateUpdated: " + contact.DateUpdated.ToShortDateString();
            Note.Content = "Note: " + contact.Note;
            Favourite.Content = "Favourite: " + contact.Favourite;

            Pfp.Source = new BitmapImage(new Uri(@"", UriKind.Relative));
        }

        private void AddressListItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddressDetails_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Address selectedAddress = (Address)AddressQuickView.SelectedItem;

            if (selectedAddress != null)
            {
                AddressDetails newWindow = new AddressDetails(Id);
                newWindow.ShowDialog();
                this.Close();
            }
        }
        private void New_Address_Click(object sender, RoutedEventArgs e)
        {
            AddAdressPage newAddressWindow = new AddAdressPage(Id);
            newAddressWindow.ShowDialog();
        }

        private void Phone_Click(object sender, RoutedEventArgs e)
        {
            PhoneDetails phoneDetailsWindow = new PhoneDetails(Id);
            phoneDetailsWindow.ShowDialog();

        }

        private void New_Phone_Click(object sender, RoutedEventArgs e)
        {
            AddPhoneNumber newPNWindow = new AddPhoneNumber(Id);
            newPNWindow.ShowDialog();
        }

        private void New_Email_Click(object sender, RoutedEventArgs e)
        {
            AddEmailPage newEMWindow = new AddEmailPage(Id);
            newEMWindow.ShowDialog();
        }


        private void Delete_Contact(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this contact?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                dbManager = new DBManager();
                dbManager.DeleteContact(Id);
                this.Close();
            }


        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

    }
}
