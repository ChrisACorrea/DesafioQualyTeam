using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DesafioQualyTeam.API.Entities;

[Index("Codigo", IsUnique = true)]
public class Documento : BaseEntity
{
    [Required]
    [RegularExpression("\\d+")]
    public string Codigo { get; set; }

    [Required]
    public string Titulo { get; set; }

    [Required]
    public string Categoria { get; set; }
 
    public DetalhesArquivo? DetalheArquivo { get; set; }

    [Required]
    public Guid? ProcessoId { get; set; } = null;

    public Processo? Processo { get; set; }
}
