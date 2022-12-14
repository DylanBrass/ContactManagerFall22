using ContactManagerFall22.DB.Entities;
using System.Windows;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public AddContact()
        {
            InitializeComponent();
        }
        public void AddContact_Button(object sender, RoutedEventArgs e)
        {
            Contact addingContact = new Contact();
        }
    }
}
