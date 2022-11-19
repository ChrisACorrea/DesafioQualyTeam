using System.ComponentModel.DataAnnotations;

namespace DesafioQualyTeam.API.Entities;

public class Arquivo : BaseEntity
{
    [Required]
    public byte[] Dados { get; set; }

    [Required]
    public Guid DetalhesArquivoId { get; set; }
}
