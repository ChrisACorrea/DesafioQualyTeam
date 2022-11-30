using DesafioQualyTeam.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioQualyTeam.API.Data.Configurations;

public class CategoriaEntityTypeConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder
            .HasData(
                new Categoria("Categoria_A_01", new Guid("8A0E1284-8B83-4D75-A5B8-7427AC40F7C0")),
                new Categoria("Categoria_A_02", new Guid("8A0E1284-8B83-4D75-A5B8-7427AC40F7C0")),
                new Categoria("Categoria_A_03", new Guid("8A0E1284-8B83-4D75-A5B8-7427AC40F7C0")),
                new Categoria("Categoria_B_01", new Guid("600F3FDA-D690-4116-B7AB-1C7740FD46C3")),
                new Categoria("Categoria_B_02", new Guid("600F3FDA-D690-4116-B7AB-1C7740FD46C3")),
                new Categoria("Categoria_B_03", new Guid("600F3FDA-D690-4116-B7AB-1C7740FD46C3"))
            );
    }
}
