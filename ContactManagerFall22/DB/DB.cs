using ContactManagerFall22.DB.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ContactManagerFall22.DB
{
    internal class DB
    {
        //GetContacts
        //GetContact
        //GetAddresses
        //GetAddress

        SqlConnection s;

        public DB()
        {
            s = new SqlConnection();
        }
        public List<Contact> GetContacts()
        {
            return null;
        }

        public Contact GetContact(int id)
        {
            return null;
        }


    }
}
