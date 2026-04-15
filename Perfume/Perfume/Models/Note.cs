namespace Perfume.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PerfumeNotes> PerfumeNotes { get; set; }
    }
}
