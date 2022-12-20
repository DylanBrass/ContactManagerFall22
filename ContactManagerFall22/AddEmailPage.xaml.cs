using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System.Windows;
using System.Windows.Controls;

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


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            if (ck.IsChecked.Value)
                radioCheck = ck.Content.ToString();
        }
    }
}
