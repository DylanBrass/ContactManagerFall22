using ContactManagerFall22.DB.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Controls.Primitives;

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
                    Contact tempCon = new Contact(Convert.ToInt32(sdr["Id"]),
                        sdr["FirstName"].ToString(),
                        sdr["LastName"].ToString());
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
                SqlCommand cm = new SqlCommand("SELECT * FROM Address a INNER JOIN TYPE t ON a.Type_Code = t.Code", connect);




                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Address tempAdd = new Address(Convert.ToInt32(sdr["Id"]),
                        sdr["City"].ToString(),
                        sdr["Country"].ToString(),
                        sdr["AreaCode"].ToString(),
                        sdr["Street"].ToString(),
                        Convert.ToInt32(sdr["AddressNumber"]),
                        Convert.ToInt32(sdr["ApartementNum"]),
                        sdr["DateCreated"].ToString(),
                        sdr["LastUpdated"].ToString(),
                        (char)sdr["Code"],
                        sdr["Description"].ToString());
                    addresses.Add(tempAdd);
                }
                sdr.Close();
                return addresses;
            }
        }

        public Address GetAddress(int Contact_Id)
        {
            using (connect)
            {
                Address address = new Address();
                connect.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM Address a INNER JOIN TYPE t ON a.Type_Code = t.Code WHERE Contact_Id = @Contact_Id AND ACTIVE = 1;", connect);

                cm.Parameters.AddWithValue("@Contact_Id", Contact_Id);


                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    address = new Address(Convert.ToInt32(sdr["Id"]),
                        sdr["City"].ToString(),
                        sdr["Country"].ToString(),
                        sdr["AreaCode"].ToString(),
                        sdr["Street"].ToString(),
                        Convert.ToInt32(sdr["AddressNumber"]),
                        Convert.ToInt32(sdr["ApartementNum"]),
                        sdr["DateCreated"].ToString(),
                        sdr["LastUpdated"].ToString(),
                        (char)sdr["Type_Code"],
                        sdr["Description"].ToString());
                }
                sdr.Close();
                return address;
            }
        }

        public TypeOf GetType(char code)
        {
            using (connect)
            {
                TypeOf type = new TypeOf();
                connect.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM Type WHERE Code = @Code;", connect);
                cm.Parameters.AddWithValue("@Code", code);

                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    type = new TypeOf((char)sdr["Code"], sdr["Description"].ToString());
                }
                sdr.Close();
                return type;

            }

        }
    }
}
