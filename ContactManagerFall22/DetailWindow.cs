namespace ContactManagerFall22
{
    internal partial class DetailWindow : MainWindow
    {
        DB db;

        public DetailWindow(int id)
        {
            InitializeComponent();

            Window_Loaded(id);
        }
        private void Window_Loaded(int id)
        {
            Contact contact = new Contact()
        }
    }
}
