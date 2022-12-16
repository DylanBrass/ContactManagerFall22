using System;

namespace ContactManagerFall22.DB.Entities
{
    internal class Phone
    {


        //For creating
        public Phone(int contact_Id, string phoneNumber, char type)
        {
            Contact_Id = contact_Id;
            PhoneNumber = phoneNumber;
            Type = type;
        }

        public Phone(int id, int contact_Id, string phoneNumber, char type, DateTime dateCreated, DateTime lastUpdated)
        {
            Id = id;
            Contact_Id = contact_Id;
            PhoneNumber = phoneNumber;
            Type = type;
            DateCreated = dateCreated;
            LastUpdated = lastUpdated;
        }

        //For reading
        public Phone(int id, int contact_Id, string phoneNumber, char type, string desc, DateTime dateCreated, DateTime lastUpdated)
        {
            Id = id;
            Contact_Id = contact_Id;
            PhoneNumber = phoneNumber;
            Type = type;
            Desc = desc;
            DateCreated = dateCreated;
            LastUpdated = lastUpdated;
        }

        public int Id { get; set; }
        public int Contact_Id { get; set; }

        public string PhoneNumber { get; set; }

        public char Type { get; set; }

        public string Desc { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }


    }
}
