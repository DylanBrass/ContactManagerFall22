namespace ContactManagerFall22.DB.Entities
{
    internal class ProfilePicture
    {
        public int Id { get; set; }
        public int Contact_Id { get; set; }
        public string Path { get; set; }
        public byte[] Image { get; set; }
    }
}
