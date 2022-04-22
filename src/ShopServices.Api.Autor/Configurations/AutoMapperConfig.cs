using AutoMapper;
using ShopServices.Api.Autor.Applications.Dtos;
using ShopServices.Api.Autor.Models;

namespace ShopServices.Api.Autor.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AutorLivro,AutorLivroDto>().ReverseMap(); 
        }
    }
}
