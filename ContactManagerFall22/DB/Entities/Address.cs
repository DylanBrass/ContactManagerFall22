namespace ContactManagerFall22.DB.Entities
{
    internal class Address
    {
        public Address(int id, string street, string country, string province)
        {
            Id = id;
            Street = street;
            Country = country;
            Province = province;
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }

        public string Province { get; set; }
    }
}
