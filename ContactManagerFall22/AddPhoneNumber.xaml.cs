using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
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
    /// Interaction logic for AddPhoneNumber.xaml
    /// </summary>
    public partial class AddPhoneNumber : Window
    {
        string radioCheck;
        readonly DBManager dB = new DBManager();
        readonly int Id;
        public AddPhoneNumber(int id)
        {
            InitializeComponent();
            Id = id;
        }
        
        private void AddPhoneNumberButton(object sender, RoutedEventArgs e)
        {
            Phone addingPhone = new Phone(Id, PNInput.Text,'0');
            addingPhone.Contact_Id = Id;
            addingPhone.PhoneNumber = PNInput.Text;
            switch (radioCheck)
            {
                case "Work":
                    addingPhone.Type = 'H';
                    break;
                case "Home":
                    addingPhone.Type = 'W';
                    break;
                default:
                    addingPhone.Type = 'O';
                    break;
            }
            addingPhone.Desc = PhoneNumDesc.Text;
            addingPhone.LastUpdated = DateTime.Now;
            addingPhone.DateCreated = DateTime.Now;
            dB.CreatePhone(addingPhone);
            this.Close();
            //I will add details to it
        }
    }
}
