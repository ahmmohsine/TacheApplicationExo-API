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
            new Tache(1, "Mettre en place la Clean Architecture", new DateTime(2026, 9, 28, 10, 0, 0), true),
            new Tache(2, "Implémenter la configuration Fluent API pour Tache", new DateTime(2026, 9, 29, 14, 30, 0), true),
            new Tache(3, "Tester l'endpoint PATCH /tache/cloture/{id}", new DateTime(2026, 9, 30, 8, 15, 0), false),
            new Tache(4, "Rédiger la documentation Swagger", new DateTime(2026, 9, 30, 9, 0, 0), false)
);
        }
    }
}