using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerFall22.DB.Entities
{
    internal class Email
    {
        public Email(int id,
            int contact_Id,
            string emailAddress,
            char type,
            DateTime dateCreated,
            DateTime lastUpdated)
        {
            this.id = id;
            Contact_Id = contact_Id;
            EmailAddress = emailAddress;
            Type = type;
            DateCreated = dateCreated;
            LastUpdated = lastUpdated;
        }

        public int id { get; set; }
        public int Contact_Id { get; set; }

        public string EmailAddress { get; set; }

        public char Type { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
