﻿using System;

namespace ContactManagerFall22.DB.Entities
{
    internal class Phone
    {
        public Phone(int id,
          int contact_Id,
          string phoneNumber,
          char type,
          string desc,
          DateTime dateCreated,
          DateTime lastUpdated)
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
