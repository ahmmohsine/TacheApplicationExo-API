using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TacheApp.Domain.Entities;

namespace TacheApp.Infrastructure.Data.Configurations
{
    public class TacheConfiguration : IEntityTypeConfiguration<Tache>
    {
        public void Configure(EntityTypeBuilder<Tache> builder)
        {
            builder.ToTable("Taches");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Titre)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.DateCreation)
                   .HasColumnType("datetime2(7)")
                   .HasDefaultValueSql("sysdatetime()");

            builder.Property(t => t.Realisee)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);

            builder.HasData(
            new Tache
            {
                Id = 1,
                Titre = "Mettre en place la Clean Architecture",
                DateCreation = new DateTime(2026, 9, 28, 10, 0, 0),
                Realisee = true
            },
            new Tache
            {
                Id = 2,
                Titre = "Implémenter la configuration Fluent API pour Tache",
                DateCreation = new DateTime(2026, 9, 29, 14, 30, 0),
                Realisee = true
            },
            new Tache
            {
                Id = 3,
                Titre = "Tester l'endpoint PATCH /tache/cloture/{id}",
                DateCreation = new DateTime(2026, 9, 30, 8, 15, 0),
                Realisee = false
            },
            new Tache
            {
                Id = 4,
                Titre = "Rédiger la documentation Swagger",
                DateCreation = new DateTime(2026, 9, 30, 9, 0, 0),
                Realisee = false
            }
        );
        }
    }
}