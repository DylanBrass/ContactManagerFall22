using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MessageBox = System.Windows.Forms.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace ContactManagerFall22
{
    /// <summary>
    /// Interaction logic for SelectingImagePage.xaml
    /// </summary>
    public partial class SelectingImagePage : Window
    {
        DBManager dBManager = new DBManager();
        ProfilePicture image = new ProfilePicture();
        string path;
        readonly int Id;
        public SelectingImagePage(int id)
        {
            InitializeComponent();
            Id = id;
        }
        private void Select(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg";
                openFileDialog.ShowDialog();
                path = openFileDialog.FileName;
                ImageSource imageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                preview.Source = imageSource;
            }
            catch
            {
                MessageBox.Show("Unexpected Error occured : Image might be too big", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                image.Contact_Id = Id;
                image.Path = path;
                image.Image = File.ReadAllBytes(path);
                dBManager.CreateImage(image);
                this.Close();
            }
            catch
            {
                MessageBox.Show("No Image selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
