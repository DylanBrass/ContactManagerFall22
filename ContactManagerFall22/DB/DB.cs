using ContactManagerFall22.DB.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ContactManagerFall22.DB
{
    internal class DBManager
    {
        //GetContacts
        //GetContact
        //GetAddresses
        //GetAddress

        SqlConnection connect;

        public DBManager()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ContactConnection"].ConnectionString;
            connect = new SqlConnection(ConString);
        }
        public List<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();
            using (connect)
            {
                connect.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM Contact", connect);




                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Contact tempCon = new Contact(Convert.ToInt32(sdr["Id"]), sdr["FirstName"].ToString(), sdr["LastName"].ToString());
                    contacts.Add(tempCon);
                }
                sdr.Close();
                return contacts;
            }
        }

        public Contact GetContact(int id)
        {
            using (connect)
            {
                Contact contact = new Contact();
                connect.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM Contact WHERE Id = @Id;", connect);

                cm.Parameters.AddWithValue("@Id", id);


                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    contact = new Contact(Convert.ToInt32(sdr["Id"]), sdr["FirstName"].ToString(), sdr["LastName"].ToString());
                }
                sdr.Close();
                return contact;
            }
        }

        public
    }
}
