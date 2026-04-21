using Microsoft.AspNetCore.Identity;

namespace Perfume.Models
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public virtual ICollection<CollectionItem> CollectionItems { get; set; } = new List<CollectionItem>();
    }
}
