namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for PhoneDetails.xaml
    /// </summary>
    public partial class PhoneDetails : Window
    {
        readonly int Id;
        public PhoneDetails(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void Phone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_PhoneNum_btn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoneNumber newPhone = new AddPhoneNumber(Id);
            newPhone.ShowDialog();
        }

        private void Edit_PhoneNum(object sender, RoutedEventArgs e)
        {
            AddPhoneNumber newPNWindow = new AddPhoneNumber(Id);
            //newPNWindow.PNInput.Text = "Hello";
            //newPNWindow.PhoneNumDesc.Text = "Hello";
            newPNWindow.ShowDialog();
        }
    }
}
