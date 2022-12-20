using ContactManagerFall22.DB.Entities;
using ContactManagerFall22.DB;
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

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for EmailDetails.xaml
    /// </summary>
    public partial class EmailDetails : Window { 

    readonly int Id;
    readonly DBManager dbManager3 = new DBManager();

    public EmailDetails(int id)
    {
        Id = id;
        InitializeComponent();
        Window_Loaded();
    }

    private void Window_Loaded()
    {
        Email email = dbManager3.GetEmail(Id);

        Email.Content = "Email: " + email.EmailAddress;
        Type.Content = "Type: " + email.Type;
        DateCreated.Content = "DateAdded: " + email.DateCreated.ToShortDateString();
        LastUpdated.Content = "DateUpdated: " + email.LastUpdated.ToShortDateString();

    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Address?", "Confirmation", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            dbManager3.DeleteEmail(Id);
            this.Close();
        }


    }

    private void Edit_Email_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
