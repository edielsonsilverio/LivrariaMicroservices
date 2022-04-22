using AutoMapper;
using ShopServices.Api.Livro.Applications.Dtos;
using ShopServices.Api.Livro.Models;

namespace ShopServices.Api.Livro.Tests;

public class MappingTest : Profile
{
    public MappingTest()
    {
        CreateMap<LivroPublicacao, LivroPublicacaoDto>().ReverseMap();
    }
}