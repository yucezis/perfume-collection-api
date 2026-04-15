namespace Perfume.Models
{
    public class CollectionItem
    {
        public int Id { get; set; }

        public int PerfumeId { get; set; }
        public Perfume Perfume { get; set; }

        public int TotalVolumeMl { get; set; }
        public int RemainingVolumeMl { get; set; }
        public bool IsFinished { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
