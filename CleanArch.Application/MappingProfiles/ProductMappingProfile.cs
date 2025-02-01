using AutoMapper;
using CleanArch.Application.Features.Product.Commands.CreateProduct;
using CleanArch.Application.Features.Product.Dtos;
using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CleanArch.Application.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CreateProductCommand, Product>();

            CreateMap<Product, ProductDto>();
        }
    }
}
