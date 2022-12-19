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
    /// Interaction logic for AddEmailPage.xaml
    /// </summary>
    public partial class AddEmailPage : Window
    {
        string radioCheck;
        readonly DBManager dB = new DBManager();
        readonly int Id;
        public AddEmailPage(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void AddEmailButton_Click(object sender, RoutedEventArgs e)
        {

            Email addingEmail = new Email();

            addingEmail.Contact_Id = Id;

            addingEmail.EmailAddress = Email.Text;

            switch (radioCheck)
            {
                case "Work":
                    addingEmail.Type = 'B';
                    break;
                case "Home":
                    addingEmail.Type = 'H';
                    break;
                default:
                    addingEmail.Type = 'O';
                    break;
            }
            dB.CreateEmail(addingEmail);
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
