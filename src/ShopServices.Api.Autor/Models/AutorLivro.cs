namespace ShopServices.Api.Autor.Models;

public class AutorLivro
{
    public int AutorLivroId { get; set; }
    public string Nome { get; set; }
    public string Apelido { get; set; }
    public DateTime? DataNascimento { get; set; }
    public ICollection<GrauAcademico> GrauAcademicos { get; set; }

    //Variavel para ser referencia entre os serviços
    public string AutorLivroGuid { get; set; }
}