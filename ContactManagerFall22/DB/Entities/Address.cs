using System;

namespace ContactManagerFall22.DB.Entities
{
    internal class Address
    {
        public Address() { }

        public Address(int id, int contact_id,
            string city,
            string country,
            string areaCode,
            string street,
            int? addressNumber,
            int? apartementNum,
            DateTime dateCreated,
            DateTime lastUpdated,
            char type,
            string desc)
        {
            Id = id;
            Contact_Id = contact_id;
            City = city;
            Country = country;
            AreaCode = areaCode;
            Street = street;
            AddressNumber = addressNumber;
            ApartementNum = apartementNum;
            DateCreated = dateCreated;
            LastUpdated = lastUpdated;
            Type = type;
            Description = desc;
        }

        public int Id { get; set; }
        public int Contact_Id { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        public string AreaCode { get; set; }

        public string Street { get; set; }

        public int? AddressNumber { get; set; }

        public int? ApartementNum { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

        public char Type { get; set; }

        public string Description { set; get; }

    }
}
