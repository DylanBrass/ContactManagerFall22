using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace ContactManagerFall22
{

    internal class CSVHandler
    {
        readonly DBManager db = new DBManager();
        List<string> filesToSave = null;

        string path;
        public void ExportCSV()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filesToSave = new List<string> { "Contacts.csv", "Addresses.csv", "Phones.csv", "Emails.csv" };
                string pathStr = folderBrowserDialog.SelectedPath;

                if (ExportContact() != "")
                {
                    path = Path.Combine(pathStr, filesToSave[0]);
                    File.WriteAllText(path, ExportContact());
                }

                if (ExportAddress() != "")
                {
                    path = Path.Combine(pathStr, filesToSave[1]);
                    File.WriteAllText(path, ExportAddress();
                }
                if (ExportPhone() != "")
                {
                    path = Path.Combine(pathStr, filesToSave[2]);
                    File.WriteAllText(path, ExportPhone());
                }
                if (ExportEmail() != "")
                {
                    path = Path.Combine(pathStr, filesToSave[3]);
                    File.WriteAllText(path, ExportEmail());
                }
            }
        }

        public string ExportContact()
        {
            StringBuilder csv = new StringBuilder();
            StringBuilder csvFileContact = new StringBuilder();

            List<Contact> contacts = db.GetContacts();

            foreach (Contact con in contacts)
            {
                var fullcon = con.GetType().GetProperties();
                foreach (var property in fullcon)
                {
                    csv.Append("," + property.GetValue(con, null).ToString());
                }
                csv.Remove(0, 1);
                csvFileContact.AppendLine(csv.ToString());
                csv.Clear();
            }
            return csvFileContact.ToString();
        }

        public string ExportAddress()
        {
            StringBuilder csv = new StringBuilder();
            StringBuilder csvFileAddress = new StringBuilder();

            List<Address> addresses = db.GetAdresses();
            if (addresses.Count > 0)
            {
                foreach (Address add in addresses)
                {
                    var fullAdd = add.GetType().GetProperties();
                    foreach (var property in fullAdd)
                    {
                        csv.Append("," + property.GetValue(add, null).ToString());
                    }
                    csv.Remove(0, 1);
                    csvFileAddress.AppendLine(csv.ToString());
                    csv.Clear();
                }
                return csvFileAddress.ToString();
            }
            return null;
        }

        public string ExportPhone()
        {
            StringBuilder csv = new StringBuilder();
            StringBuilder csvFilePhone = new StringBuilder();

            List<Phone> phones = db.GetPhones();
            if (phones.Count > 0)
            {
                foreach (Phone ph in phones)
                {
                    var fullPh = ph.GetType().GetProperties();
                    foreach (var property in fullPh)
                    {
                        csv.Append("," + property.GetValue(ph, null).ToString());
                    }
                    csv.Remove(0, 1);
                    csvFilePhone.AppendLine(csv.ToString());
                    csv.Clear();
                }
                return csvFilePhone.ToString();

            }
            return null;
        }

        public string ExportEmail()
        {
            StringBuilder csv = new StringBuilder();
            StringBuilder csvFileEmail = new StringBuilder();

            List<Email> emails = db.GetEmails();

            if (emails.Count > 0)
            {
                foreach (Email em in emails)
                {
                    var fullEm = em.GetType().GetProperties();
                    foreach (var property in fullEm)
                    {
                        csv.Append("," + property.GetValue(em, null).ToString());
                    }
                    csv.Remove(0, 1);
                    csvFileEmail.AppendLine(csv.ToString());
                    csv.Clear();
                }
                return csvFileEmail.ToString();
            }
            return null;
        }

        public void ImportCSV()
        {
            ImportContact();
        }
        public void ImportContact()
        {
            string[] lines;
            Contact contact = new Contact();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                lines = File.ReadAllLines(openFileDialog.FileName);

                List<Contact> contacts = lines.Select(line =>
                {
                    string[] data = line.Split(',');
                    return new Contact(Convert.ToInt32(data[0]), data[1], data[2], Convert.ToDateTime(data[3]), Convert.ToDateTime(data[4]), Convert.ToBoolean(data[5]), Convert.ToBoolean(data[6]), data[7], data[8], Convert.ToDateTime(data[9]), data[10]);
                }).ToList();
                foreach (Contact con in contacts)
                {
                    db.CreateContact(con);
                }

            }
        }

    }
}
