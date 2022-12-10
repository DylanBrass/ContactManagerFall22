using System;

namespace ContactManagerFall22.DB.Entities
{
    internal class Contact
    {
        public Contact()
        {

        }
        public Contact(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Contact(int id,
            string firstName,
            string lastName,
            DateTime dateAdded,
            DateTime dateUpdated,
            string email,
            bool favourite,
            bool active,
            string salutation,
            string nickname,
            DateTime birthday,
            string note) : this(id, firstName, lastName)
        {
            DateAdded = dateAdded;
            DateUpdated = dateUpdated;
            Email = email;
            Favourite = favourite;
            Active = active;
            Salutation = salutation;
            Nickname = nickname;
            Birthday = birthday;
            Note = note;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateUpdated { get; set; }

        public string Email { get; set; }

        public bool Favourite { get; set; }

        public bool Active { get; set; }

        public string Salutation { get; set; }

        public string Nickname { get; set; }

        public DateTime Birthday { get; set; }

        public string Note { get; set; }
    }
}
