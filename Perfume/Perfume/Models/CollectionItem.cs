using Microsoft.AspNetCore.SignalR;

namespace Perfume.Models
{
    public class CollectionItem
    {
        public int Id { get; set; }

        public int PerfumeId { get; set; }
        public Perfume? Perfume { get; set; }

        public int TotalVolumeMl { get; set; }
        public int RemainingVolumeMl { get; set; }
        public bool IsFinished { get; set; }
        public DateTime PurchaseDate { get; set; }

        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
