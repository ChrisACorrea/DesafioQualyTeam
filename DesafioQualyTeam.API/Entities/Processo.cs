using System.ComponentModel.DataAnnotations;

namespace DesafioQualyTeam.API.Entities;

public class Processo : BaseEntity
{
    [Required]
    public string Nome { get; set; }

    public Processo(string nome)
    {
        Nome = nome;
    }
}
