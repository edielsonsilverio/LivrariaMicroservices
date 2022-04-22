namespace ShopServices.Api.Autor.Models;

public class GrauAcademico
{
    public int GrauAcademicoId { get; set; }
    public string Nome { get; set; }
    public string CentroAcademico { get; set; }
    public DateTime? DataNota { get; set; }

    public int AutorLivroId { get; set; }
    public AutorLivro AutorLivro { get; set; }

    //Variavel para ser referencia entre os serviços
    public string GrauAcademicoGuid { get; set; }
}