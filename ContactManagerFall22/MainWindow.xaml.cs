﻿using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBManager db = new DBManager();
        readonly CSVHandler csvHandler = new CSVHandler();
        // Shows the window.
        public MainWindow()
        {
            InitializeComponent();
            Window_Loaded();
        }

        private void Window_Loaded()
        {
            List<Contact> Contacts = db.GetContacts();
            ContactsListItems.ItemsSource = Contacts;
        }

        public void Refresh()
        {
            MainWindow newWin = new MainWindow();
            newWin.Show();
            db = new DBManager();
            List<Contact> Contacts = db.GetContacts();
            ContactsListItems.ItemsSource = Contacts;
        }

        private void ContactsListItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Contact selectedContact = (Contact)ContactsListItems.SelectedItem;

            if (selectedContact != null)
            {
                DetailsPage newWindow = new DetailsPage(selectedContact.Id);
                newWindow.ShowDialog();
                db = new DBManager();
                List<Contact> Contacts = db.GetContacts();
                ContactsListItems.ItemsSource = Contacts;
            }
        }


        private void Add_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            AddContact addContactWindow = new AddContact();
            addContactWindow.ShowDialog();
            db = new DBManager();
            List<Contact> Contacts = db.GetContacts();
            ContactsListItems.ItemsSource = Contacts;
        }

        private void Edit_Contact_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Contact_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Imp_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            csvHandler.ImportContact();
            db = new DBManager();
            List<Contact> Contacts = db.GetContacts();
            ContactsListItems.ItemsSource = Contacts;
        }

        private void Ex_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            csvHandler.ExportContact();
        }

        private void ContactsListItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }

        private void FavouriteSort_Click(object sender, RoutedEventArgs e)
        {
            List<Contact> contacts = new List<Contact>();
            contacts = db.GetContacts();
            List<Contact> contactsSorted = contacts.OrderByDescending(con => con.Favourite).ToList();
            ContactsListItems.ItemsSource = contactsSorted;
        }


        private void LastNameSort_Click(object sender, RoutedEventArgs e)
        {
            List<Contact> contacts = new List<Contact>();
            contacts = db.GetContacts();
            List<Contact> contactsSorted = contacts.OrderBy(con => con.LastName).ToList();
            ContactsListItems.ItemsSource = contactsSorted;
        }

        private void LastNameSortReverse_Click(object sender, RoutedEventArgs e)
        {
            List<Contact> contacts = new List<Contact>();
            contacts = db.GetContacts();
            List<Contact> contactsSorted = contacts.OrderByDescending(con => con.LastName).ToList();
            ContactsListItems.ItemsSource = contactsSorted;
        }
    }


}



//To make the favourite on to create a list and group by with lambda
//So get all contacts and then group by true and false for favorite from the contact