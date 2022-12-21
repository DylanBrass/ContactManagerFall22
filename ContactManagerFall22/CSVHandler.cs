using ContactManagerFall22.DB;
using ContactManagerFall22.DB.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace ContactManagerFall22
{

    internal class CSVHandler
    {
        readonly DBManager db = new DBManager();
        string[] lines = null;

        public void ExportContact()
        {
            try
            {
                StringBuilder csv = new StringBuilder();
                StringBuilder csvFileContact = new StringBuilder();
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    InitialDirectory = "c:\\",
                    Filter = "CSV Files (*.csv)|*.csv"
                };

                if (saveFileDialog.ShowDialog() == true)
                {


                    List<Contact> contacts = db.GetContacts();

                    foreach (Contact con in contacts)
                    {
                        PropertyInfo[] fullcon = con.GetType().GetProperties();
                        foreach (PropertyInfo property in fullcon)
                        {
                            csv.Append("," + property.GetValue(con, null).ToString());
                        }
                        csv.Remove(0, 1);
                        csvFileContact.AppendLine(csv.ToString());
                        csv.Clear();
                    }
                    File.WriteAllText(saveFileDialog.FileName, csvFileContact.ToString());
                }
            }
            catch
            {
                MessageBox.Show("File is used by another program !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
        public void ExportAddress(int contact_id)
        {
            try
            {
                StringBuilder csv = new StringBuilder();
                StringBuilder csvFileAddress = new StringBuilder();
                SaveFileDialog openFileDialog = new SaveFileDialog
                {
                    InitialDirectory = "c:\\",
                    Filter = "CSV Files (*.csv)|*.csv"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    List<Address> addresses = db.GetAdresses(contact_id);
                    if (addresses.Count > 0)
                    {
                        foreach (Address add in addresses)
                        {
                            PropertyInfo[] fullAdd = add.GetType().GetProperties();
                            foreach (PropertyInfo property in fullAdd)
                            {
                                csv.Append("," + property.GetValue(add, null).ToString());
                            }
                            csv.Remove(0, 1);
                            csvFileAddress.AppendLine(csv.ToString());
                            csv.Clear();
                        }
                        File.WriteAllText(openFileDialog.FileName, csvFileAddress.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("File is used by another program !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        public void ExportPhone(int contact_id)
        {
            try
            {
                StringBuilder csv = new StringBuilder();
                StringBuilder csvFilePhone = new StringBuilder();
                SaveFileDialog openFileDialog = new SaveFileDialog
                {
                    InitialDirectory = "c:\\",
                    Filter = "CSV Files (*.csv)|*.csv"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    List<Phone> phones = db.GetPhones(contact_id);
                    if (phones.Count > 0)
                    {
                        foreach (Phone ph in phones)
                        {
                            PropertyInfo[] fullPh = ph.GetType().GetProperties();
                            foreach (PropertyInfo property in fullPh)
                            {
                                csv.Append("," + property.GetValue(ph, null).ToString());
                            }
                            csv.Remove(0, 1);
                            csvFilePhone.AppendLine(csv.ToString());
                            csv.Clear();
                        }
                        File.WriteAllText(openFileDialog.FileName, csvFilePhone.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("File is used by another program !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        public void ExportEmail(int contact_id)
        {
            try
            {
                StringBuilder csv = new StringBuilder();
                StringBuilder csvFileEmail = new StringBuilder();
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    InitialDirectory = "c:\\",
                    Filter = "CSV Files (*.csv)|*.csv"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    List<Email> emails = db.GetEmails(contact_id);

                    if (emails.Count > 0)
                    {
                        foreach (Email em in emails)
                        {
                            PropertyInfo[] fullEm = em.GetType().GetProperties();
                            foreach (PropertyInfo property in fullEm)
                            {
                                csv.Append("," + property.GetValue(em, null).ToString());
                            }
                            csv.Remove(0, 1);
                            csvFileEmail.AppendLine(csv.ToString());
                            csv.Clear();
                        }
                        File.WriteAllText(saveFileDialog.FileName, csvFileEmail.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("File is used by another program !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        public void ImportCSV()
        {
            try
            {
                string currentfile;
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Multiselect = true,
                    Filter = "CSV Files (*.csv)|*.csv",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        currentfile = Path.GetFileName(fileName);


                        lines = File.ReadAllLines(fileName);
                        ImportContact();

                    }
                }
            }
            catch
            {
                MessageBox.Show("File is used by another program !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
        public void ImportContact()
        {
            try
            {
                string[] lines;
                string currentfile;
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Multiselect = true,
                    Filter = "CSV Files (*.csv)|*.csv",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        currentfile = Path.GetFileName(fileName);


                        lines = File.ReadAllLines(fileName);
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
            catch
            {
                MessageBoxResult result = MessageBox.Show("File is used by another program !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }

        public void ImportAddress(int contact_id)
        {
            try
            {
                string[] lines;
                string currentfile;
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Multiselect = true,
                    Filter = "CSV Files (*.csv)|*.csv",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        currentfile = Path.GetFileName(fileName);
                        lines = File.ReadAllLines(fileName);
                        List<Address> addresses = lines.Select(line =>
                        {
                            string[] data = line.Split(',');
                            return new Address(Convert.ToInt32(data[0]), contact_id, data[2], data[3], data[4], data[5], Convert.ToInt32(data[6]), Convert.ToInt32(data[7]), Convert.ToDateTime(data[8]), Convert.ToDateTime(data[9]), Convert.ToChar(data[10]));
                        }).ToList();
                        foreach (Address add in addresses)
                        {
                            db.CreateAddress(add);
                        }

                    }
                }
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("File is used by another program !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }

        public void ImportPhone(int contact_id)
        {
            try
            {
                string[] lines;

                string currentfile;
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Multiselect = true,
                    Filter = "CSV Files (*.csv)|*.csv",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        currentfile = Path.GetFileName(fileName);


                        lines = File.ReadAllLines(fileName);
                        List<Phone> phones = lines.Select(line =>
                        {
                            string[] data = line.Split(',');
                            return new Phone(Convert.ToInt32(data[0]), contact_id, data[2], Convert.ToChar(data[3]), Convert.ToDateTime(data[5]), Convert.ToDateTime(data[6]));
                        }).ToList();
                        foreach (Phone ph in phones)
                        {
                            db.CreatePhone(ph);
                        }

                    }

                }
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("File is used by another program !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }


        public void ImportEmail(int contact_id)
        {
            try
            {
                string[] lines;

                string currentfile;
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Multiselect = true,
                    Filter = "CSV Files (*.csv)|*.csv",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        currentfile = Path.GetFileName(fileName);


                        lines = File.ReadAllLines(fileName);
                        List<Email> emails = lines.Select(line =>
                        {
                            string[] data = line.Split(',');
                            return new Email(Convert.ToInt32(data[0]), contact_id, data[2], Convert.ToChar(data[3]), Convert.ToDateTime(data[5]), Convert.ToDateTime(data[6]));
                        }).ToList();
                        foreach (Email em in emails)
                        {
                            db.CreateEmail(em);
                        }

                    }
                }
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("File is used by another program !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }

    }
}

