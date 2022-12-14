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
        readonly string ConString = ConfigurationManager.ConnectionStrings["ContactConnection"].ConnectionString;

        public DBManager()
        {
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
                        sdr["LastName"].ToString(),
                        (DateTime)sdr["DateAdded"],
                        (DateTime)sdr["LastUpdated"],
                        sdr["Email"].ToString(),
                        (bool)sdr["Favourite"],
                        (bool)sdr["Active"],
                        sdr["Salutation"].ToString(),
                        sdr["Nickname"].ToString(),
                        (DateTime)sdr["Birthday"],
                        sdr["Note"].ToString());

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
                        (DateTime)sdr["DateAdded"],
                        (DateTime)sdr["LastUpdated"],
                        sdr["Email"].ToString(),
                        (bool)sdr["Favourite"],
                        (bool)sdr["Active"],
                        sdr["Salutation"].ToString(),
                        sdr["Nickname"].ToString(),
                        (DateTime)sdr["Birthday"],
                        sdr["Note"].ToString());
                }
                sdr.Close();
                return contact;
            }
        }

        public List<Address> GetAdresses(int Contact_Id)
        {
            List<Address> addresses = new List<Address>();

            using (connect)
            {
                connect = new SqlConnection(ConString);


                connect.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM Address a INNER JOIN TYPE t ON a.Type_Code = t.Code WHERE Contact_Id = @Contact_Id AND ACTIVE = 1;", connect);

                cm.Parameters.AddWithValue("@Contact_Id", Contact_Id);


                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Address address = new Address();
                    address = new Address(Convert.ToInt32(sdr["Id"]),
                        Convert.ToInt32(sdr["Contact_Id"]),
                        sdr["City"].ToString(),
                        sdr["Country"].ToString(),
                        sdr["AreaCode"].ToString(),
                        sdr["Street"].ToString(),
                        sdr["AddressNumber"] == DBNull.Value ? default(int) : int.Parse(sdr["AddressNumber"].ToString()),
                        //To avoid DBNull Thanks Brendan !
                        sdr["ApartementNum"] == DBNull.Value ? default(int) : int.Parse(sdr["ApartementNum"].ToString()),
                        (DateTime)sdr["DateCreated"],
                        (DateTime)sdr["LastUpdated"],
                        Convert.ToChar(sdr["Type_Code"]),
                        sdr["Description"].ToString());
                    addresses.Add(address);
                }
                sdr.Close();
                return addresses;
            }
        }

        public Address GetAddress(int Address_Id)
        {
            using (connect)
            {
                Address address = new Address();
                connect.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM Address a INNER JOIN TYPE t ON a.Type_Code = t.Code WHERE Id = @Address_Id AND ACTIVE = 1;", connect);

                cm.Parameters.AddWithValue("@Address_Id", Address_Id);


                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    address = new Address(Convert.ToInt32(sdr["Id"]), Convert.ToInt32(sdr["Contact_Id"]),
                        sdr["City"].ToString(),
                        sdr["Country"].ToString(),
                        sdr["AreaCode"].ToString(),
                        sdr["Street"].ToString(),
                        sdr["AddressNumber"] == DBNull.Value ? default(int) : int.Parse(sdr["AddressNumber"].ToString()),
                        sdr["ApartementNum"] == DBNull.Value ? default(int) : int.Parse(sdr["ApartementNum"].ToString()),
                        (DateTime)sdr["DateCreated"],
                        (DateTime)sdr["LastUpdated"],
                        Convert.ToChar(sdr["Type_Code"]),
                        sdr["Description"].ToString());
                }
                sdr.Close();
                return address;
            }
        }


        public List<Phone> GetPhones(int Contact_Id)
        {
            List<Phone> phones = new List<Phone>();
            Phone phone;
            using (connect)
            {
                connect.Open();

                SqlCommand cm = new SqlCommand("SELECT * FROM Phone p INNER JOIN TYPE t ON p.Type_Code = t.Code WHERE Contact_Id = @Contact_Id AND ACTIVE = 1;", connect);

                cm.Parameters.AddWithValue("@Contact_Id", Contact_Id);
                SqlDataReader sdr = cm.ExecuteReader();

                while (sdr.Read())
                {
                    phone = new Phone(Convert.ToInt32(sdr["Id"]),
                        Convert.ToInt32(sdr["Contact_Id"]),
                        sdr["Phone_Number"].ToString(),
                        Convert.ToChar(sdr["Type_Code"]),
                        sdr["Description"].ToString(),
                        (DateTime)sdr["DateCreated"],
                        (DateTime)sdr["LastUpdated"]);

                    phones.Add(phone);
                }
                sdr.Close();

                return phones;
            }
        }
        public List<Email> GetEmails(int Contact_Id)
        {
            List<Email> emails = new List<Email>();
            Email email;
            using (connect)
            {
                connect.Open();

                SqlCommand cm = new SqlCommand("SELECT * FROM Email e INNER JOIN TYPE t ON e.Type_Code = t.Code WHERE Contact_Id = @Contact_Id AND ACTIVE = 1;", connect);

                cm.Parameters.AddWithValue("@Contact_Id", Contact_Id);
                SqlDataReader sdr = cm.ExecuteReader();

                while (sdr.Read())
                {
                    email = new Email(Convert.ToInt32(sdr["Id"]),
                        Convert.ToInt32(sdr["Contact_Id"]),
                        sdr["Email"].ToString(),
                        Convert.ToChar(sdr["Type_Code"]),
                        sdr["Description"].ToString(),
                        (DateTime)sdr["DateCreated"],
                        (DateTime)sdr["LastUpdated"]);

                    emails.Add(email);
                }
                sdr.Close();

                return emails;
            }
        }


        public void CreateContact(Contact con)
        {
            using (connect)
            {
                AddContact addContact = new AddContact();
                connect.Open();
                SqlCommand cm = new SqlCommand("INSERT INTO Contact (FirstName,LastName,Email,Favourite,Active,Salutation,Nickname,Birthday,Note) VALUES (@FirstName,@LastName,@Email,@Favourite,@Active,@Salutation,@Nickname,@Birthday,@Note);", connect);


                cm.Parameters.AddWithValue("@FirstName", con.FirstName);
                cm.Parameters.AddWithValue("@LastName", con.LastName);
                cm.Parameters.AddWithValue("@Email", con.Email);
                cm.Parameters.AddWithValue("@Favourite", con.Favourite);
                cm.Parameters.AddWithValue("@Active", true);
                cm.Parameters.AddWithValue("@Salutation", con.Salutation);
                cm.Parameters.AddWithValue("@Nickname", con.Nickname);
                cm.Parameters.AddWithValue("@Birthday", con.Birthday);
                cm.Parameters.AddWithValue("@Note", con.Note);
                cm.ExecuteNonQuery();

                //public void CreateContact(Contact con)
                //return addContact;

            }


        }

        public void CreateAddress(Address add)
        {
            using (connect)
            {
                connect.Open();
                SqlCommand cm = new SqlCommand("INSERT INTO Address (Contact_Id,City,Country,AreaCode,Street,AddressNumber,ApartementNum,Type_Code) " +
                    "VALUES (@Contact_Id,@City,@Country,@AreaCode,@Street,@AddressNumber,@ApartementNum,@Active,@Type_Code);", connect);


                cm.Parameters.AddWithValue("@Contact_Id", add.Contact_Id);
                cm.Parameters.AddWithValue("@City", add.City);
                cm.Parameters.AddWithValue("@Country", add.Country);
                cm.Parameters.AddWithValue("@AreaCode", add.AreaCode);
                cm.Parameters.AddWithValue("@Street", add.Street);
                cm.Parameters.AddWithValue("@AddressNumber", add.AddressNumber);
                cm.Parameters.AddWithValue("@ApartementNum", add.ApartementNum);
                cm.Parameters.AddWithValue("@Active", true);
                cm.Parameters.AddWithValue("@Type_Code", add.Type);
                cm.ExecuteNonQuery();
            }
        }

        public void CreatePhone()
        {

        }

        public void CreateAddress()
        {

        }

        public void CreacteEmail()
        {

        }


        public void DeleteContact(int id)
        {
            SqlCommand cm = new SqlCommand("UPDATE Contact SET Active = False WHERE Id = @Id;");
            DeleteAddress(id);
            DeleteEmail(id);
            DeletePhone(id);
            cm.Parameters.AddWithValue("@Id", id);
            if (cm.ExecuteNonQuery() > 0)
            {
                cm.ExecuteNonQuery();
            }
        }

        public void DeleteAddress(int contact_id)
        {
            SqlCommand cm = new SqlCommand("UPDATE Address SET Active = False WHERE Contact_Id = @Contact_Id;");

        }
        public void DeleteEmail(int contact_id)
        {
            SqlCommand cm = new SqlCommand("UPDATE Email SET Active = False WHERE Contact_Id = @Contact_Id;");

        }
        public void DeletePhone(int contact_id)
        {
            SqlCommand cm = new SqlCommand("UPDATE Phoen SET Active = False WHERE Contact_Id = @Contact_Id;");

        }


    }
}
/*
     * public TypeOf GetType(char code)
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
    */