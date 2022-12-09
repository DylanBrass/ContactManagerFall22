using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerFall22.DB.Entities
{
    internal class Phone
    {
        public Phone(int id,
          int contact_Id,
          string phoneNumber,
          char type,
          DateTime dateCreated,
          DateTime lastUpdated)
        {
            Id = id;
            Contact_Id = contact_Id;
            PhoneNumber = phoneNumber;
            Type = type;
            DateCreated = dateCreated;
            LastUpdated = lastUpdated;
        }
        public int Id { get; set; }

        public int Contact_Id { get; set; }

        public string PhoneNumber { get; set; }

        public char Type { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }


    }
}
