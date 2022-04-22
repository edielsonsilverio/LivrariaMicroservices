using AutoMapper;
using ShopServices.Api.Livro.Applications.Dtos;
using ShopServices.Api.Livro.Models;

namespace ShopServices.Api.Livro.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<LivroPublicacao, LivroPublicacaoDto>().ReverseMap();
        }
    }
}
