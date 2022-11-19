using System.ComponentModel.DataAnnotations;

namespace DesafioQualyTeam.API.Entities;

public class DetalhesArquivo : BaseEntity
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public string ContentType { get; set; }

    [Required]
    public Guid DocumentoId { get; set; }

    public Arquivo? Arquivo { get; set; }
}
