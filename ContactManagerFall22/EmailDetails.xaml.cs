using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System.Windows;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for EmailDetails.xaml
    /// </summary>
    public partial class EmailDetails : Window
    {

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
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Email?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                dbManager3.DeleteEmail(Id);
                this.Close();
            }


        }

        private void Edit_Email_btn_Click(object sender, RoutedEventArgs e)
        {
            Email inputedPEmail = dbManager3.GetEmail(Id);

            EditEmail editpage = new EditEmail(Id);


            editpage.Email.Text = inputedPEmail.EmailAddress;

            if (inputedPEmail.Type == 'H')
            {
                editpage.Home.IsChecked = true;
            }
            else if (inputedPEmail.Type == 'B')
            {
                editpage.Work.IsChecked = true;

            }
            else
            {
                editpage.Other.IsChecked = true;

            }
            editpage.ShowDialog();

            Window_Loaded();
        }
    }
}
