namespace Perfume.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<Perfume> Perfumes { get; set; }
    }
}
