namespace ContactManagerFall22.DB.Entities
{
    internal class Address
    {
        public Address()
        {

        }

        public Address(int id,
            string city,
            string country,
            string areaCode,
            string street,
            int addressNumber,
            int apartementNum,
            string dateCreated,
            string lastUpdated,
            char type,
            string desc)
        {
            Id = id;
            City = city;
            Country = country;
            AreaCode = areaCode;
            Street = street;
            AddressNumber = addressNumber;
            ApartementNum = apartementNum;
            DateCreated = dateCreated;
            LastUpdated = lastUpdated;
            this.type = type;
            this.Description = desc;
        }

        public int Id { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        public string AreaCode { get; set; }

        public string Street { get; set; }

        public int AddressNumber { get; set; }

        public int ApartementNum { get; set; }

        public string DateCreated { get; set; }

        public string LastUpdated { get; set; }

        public char type { get; set; }

        public string Description { set; get; }

    }
}
