namespace ShopServices.Api.Gateway.Applications.Dtos
{
    public class AutorDto
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime? DataNascimento { get; set; }

        //Variavel para ser referencia entre os serviços
        public string AutorLivroGuid { get; set; }
    }
}
