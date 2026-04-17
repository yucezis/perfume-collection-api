using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Perfume.Models;

namespace Perfume.Data
{
    public class PerfumeDbContext : IdentityDbContext<AppUser>
    {
        public PerfumeDbContext(DbContextOptions<PerfumeDbContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Perfume.Models.Perfume> Perfumes { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<PerfumeNotes> PerfumeNotes { get; set; }
        public DbSet<CollectionItem> CollectionItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PerfumeNotes>()
                .HasKey(pn => new { pn.PerfumeId, pn.NoteId });

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.CollectionItems)
                .WithOne(c => c.AppUser)
                .HasForeignKey(c => c.UserId);
        }

    }
}
