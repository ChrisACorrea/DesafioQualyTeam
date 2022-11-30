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
    public Guid CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

    public DetalhesArquivo? DetalheArquivo { get; set; }

    [Required]
    public Guid? ProcessoId { get; set; } = null;

    public Processo? Processo { get; set; }
}

public static class DocumentoUtils {
    public static string[] TiposArquivoAceitos { get; } = { "application/msword", 
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        "application/pdf",
        "application/vnd.ms-excel",
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
    };

    public static bool isArquivoAceito(string contenType)
    {
        return TiposArquivoAceitos.Contains(contenType);
    }
}
