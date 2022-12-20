namespace ContactManagerFall22.DB.Entities
{
    internal class Images
    {
        public byte[] Image { get; set; }
        public int Contact_Id { get; set; }

        public Images(byte[] image, int contact_Id)
        {
            Image = image;
            Contact_Id = contact_Id;
        }

        public Images()
        {
        }

        public int Id { get; set; }
    }
}
