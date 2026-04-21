using Perfume.Models.Enum;

namespace Perfume.Models
{
    public class Perfume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public ScentFamily Family { get; set; }

        public ICollection<PerfumeNotes>? PerfumeNotes { get; set; } 
    }
}
