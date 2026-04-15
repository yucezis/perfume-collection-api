using Perfume.Models.Enum;

namespace Perfume.Models
{
    public class PerfumeNotes
    {
        public int PerfumeId { get; set; }
        public Perfume? Perfume { get; set; }
        public int NoteId { get; set; }
        public Note? Note { get; set; }
        public NoteType Type { get; set; }
    }
}
