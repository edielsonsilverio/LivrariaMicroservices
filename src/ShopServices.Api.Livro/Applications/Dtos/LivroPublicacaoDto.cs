﻿namespace ShopServices.Api.Livro.Applications.Dtos
{
    public class LivroPublicacaoDto
    {
        public Guid? BibliotecaId { get; set; }
        public string Titulo { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public Guid? AutorLivro { get; set; }
    }
}
