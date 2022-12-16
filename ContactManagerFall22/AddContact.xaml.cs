﻿using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        readonly DBManager dB = new DBManager();
        public AddContact()
        {
            InitializeComponent();
        }
        public void AddContact_Button(object sender, RoutedEventArgs e)
        {
            //Contact addingContact = new Contact(FName.Text, LName.Text, email.Text, Salutation.Text, Nickname.Text, Birthday.Text,);
            Contact addingContact = new Contact();
            addingContact.FirstName = FName.Text;
            addingContact.LastName = LName.Text;
            addingContact.Nickname = Nickname.Text;
            DateTime stringBD  = Convert.ToDateTime(BirthDate.Text);
            addingContact.Birthday = stringBD;
            addingContact.Salutation = Salutation.Text;
            addingContact.Note = Note.Text;
            addingContact.Favourite = favourite.IsChecked;
            dB.CreateContact(addingContact);
            this.Close();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
