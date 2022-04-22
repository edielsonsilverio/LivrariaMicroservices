namespace ShopServices.Api.Autor.Applications.Dtos
{
    public class AutorLivroDto
    {
            public string Nome { get; set; }
            public string Apelido { get; set; }
            public DateTime? DataNascimento { get; set; }

            //Variavel para ser referencia entre os serviços
            public string AutorLivroGuid { get; set; }
    }
}
