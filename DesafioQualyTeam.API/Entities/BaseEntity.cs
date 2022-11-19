using System.ComponentModel.DataAnnotations;

namespace DesafioQualyTeam.API.Entities;

public abstract class BaseEntity
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    public DateTime Criacao { get; set; }

    [Required]
    public DateTime UltimaAtualizacao { get; set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
        Criacao = UltimaAtualizacao = DateTime.Now;
    }
}
