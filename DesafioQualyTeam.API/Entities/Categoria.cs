using System.ComponentModel.DataAnnotations;

namespace DesafioQualyTeam.API.Entities;

public class Categoria : BaseEntity
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public Guid ProcessoId { get; set; }
    public Processo? Processo { get; set; }

    public Categoria(string nome, Guid processoId)
    {
        Nome = nome;
        ProcessoId = processoId;
    }
}
