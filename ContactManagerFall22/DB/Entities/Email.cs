using System;

namespace ContactManagerFall22.DB.Entities
{
    internal class Email
    {
        public Email(int id,
            int contact_Id,
            string emailAddress,
            char type,
            string desc,
            DateTime dateCreated,
            DateTime lastUpdated)
        {
            Id = id;
            Contact_Id = contact_Id;
            EmailAddress = emailAddress;
            Type = type;
            Desc = desc;
            DateCreated = dateCreated;
            LastUpdated = lastUpdated;
        }

        public Email(int contact_Id, string emailAddress, char type)
        {
            Contact_Id = contact_Id;
            EmailAddress = emailAddress;
            Type = type;
        }

        public Email(int id, int contact_Id, string emailAddress, char type, DateTime dateCreated, DateTime lastUpdated)
        {
            Id = id;
            Contact_Id = contact_Id;
            EmailAddress = emailAddress;
            Type = type;
            DateCreated = dateCreated;
            LastUpdated = lastUpdated;
        }

        public int Id { get; set; }
        public int Contact_Id { get; set; }

        public string EmailAddress { get; set; }

        public char Type { get; set; }

        public string Desc { get; set; }
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
