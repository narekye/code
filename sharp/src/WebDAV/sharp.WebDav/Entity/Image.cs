namespace sharp.WebDav.Entity
{
    internal class Image
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public int ClientId { get; set; }
        public ImageType Type { get; set; }
        public int Size { get; set; }
        public State State { get; set; }
        public int MediaType { get; set; }
    }
}
