using AutoMapper;
using Prueba.Tekton.Application.Features.Products.Commands.CreateProduct;
using Prueba.Tekton.Application.Features.Products.Queries.GetProduct;
using Prueba.Tekton.Domain;

namespace Prueba.Tekton.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Product, ProductVM>();
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
