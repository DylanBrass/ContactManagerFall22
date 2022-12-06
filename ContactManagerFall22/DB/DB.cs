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
                SqlCommand cm = new SqlCommand("SELECT * FROM Contact WHERE Id = @Id AND ACTIVE = 1;", connect);

                cm.Parameters.AddWithValue("@Id", id);


                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    contact = new Contact(Convert.ToInt32(sdr["Id"]),
                        sdr["FirstName"].ToString(),
                        sdr["LastName"].ToString(),
                        sdr["DateAdded"].ToString(),
                        sdr["LastUpdated"].ToString(),
                        sdr["Email"].ToString(),
                        (bool)sdr["Favourite"],
                        (bool)sdr["Active"],
                        sdr["Salutation"].ToString(),
                        sdr["Nickname"].ToString(),
                        sdr["Birthday"].ToString(),
                        sdr["Note"].ToString());
                }
                sdr.Close();
                return contact;
            }
        }

        public List<Address> GetAdresses()
        {
            using (connect)
            {
                List<Address> addresses = new List<Address>();
                connect.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM Address", connect);




                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Address tempAdd = new Address(Convert.ToInt32(sdr["Id"]), sdr["AreaCode"].ToString(), sdr["Street"].ToString(), sdr["Country"].ToString());
                    addresses.Add(tempAdd);
                }
                sdr.Close();
                return addresses;
            }
        }

        public Address GetAddress(int Contact_Id)
        {
            return null;
        }
    }
}
