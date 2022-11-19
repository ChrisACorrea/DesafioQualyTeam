using DesafioQualyTeam.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioQualyTeam.API.Data.Configurations;

public class ProcessoEntityTypeConfiguration : IEntityTypeConfiguration<Processo>
{
    public void Configure(EntityTypeBuilder<Processo> builder)
    {
        builder
            .HasData(
                new Processo("Processo_01") { Id = new Guid("8A0E1284-8B83-4D75-A5B8-7427AC40F7C0") },
                new Processo("Processo_02") { Id = new Guid("600F3FDA-D690-4116-B7AB-1C7740FD46C3") },
                new Processo("Processo_03") { Id = new Guid("EE5FE867-FE4E-40D3-BDA6-9EE6D3D71714") },
                new Processo("Processo_04") { Id = new Guid("B4185D9E-F665-4BEE-B764-ADE04036354E") },
                new Processo("Processo_05") { Id = new Guid("66F30AB7-FC63-4347-9C94-755D8C0F790F") }
            );
    }
}
