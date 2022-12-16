using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly DBManager db = new DBManager();

        // Shows the window.
        public MainWindow()
        {
            InitializeComponent();
            Window_Loaded();
        }

        private void Window_Loaded()
        {
            List<Contact> Contacts = new List<Contact>();
            Contacts = db.GetContacts();
            ContactsListItems.ItemsSource = Contacts;
        }

        public void Refresh()
        {
            MainWindow newWin = new MainWindow();
            newWin.Show();
            this.Close();
        }

        private void ContactsListItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Contact selectedContact = (Contact)ContactsListItems.SelectedItem;

            if (selectedContact != null)
            {
                DetailsPage newWindow = new DetailsPage(selectedContact.Id);
                newWindow.ShowDialog();
                this.Close();
            }
        }


        private void Add_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            AddContact addContactWindow = new AddContact();
            addContactWindow.ShowDialog();
            this.Close();

        }

        private void Edit_Contact_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Contact_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Imp_Contact_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ex_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder csv = new StringBuilder();
            StringBuilder csvFile = new StringBuilder();

            List<Contact> contacts = db.GetContacts();

            foreach (Contact con in contacts)
            {
                var fullcon = con.GetType().GetProperties();
                foreach (var property in fullcon)
                {
                    csv.Append("," + property.GetValue(con, null).ToString());
                }
                csv.Remove(0, 1);
                csvFile.AppendLine(csv.ToString());
                csv.Clear();
            }
            string csvContent = csvFile.ToString();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, csvContent);
        }

        private void ContactsListItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }


    }
}


//To make the favourite on to create a list and group by with lambda
//So get all contacts and then group by true and false for favorite from the contact