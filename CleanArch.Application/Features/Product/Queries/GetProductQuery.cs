using CleanArch.Application.Features.Product.Dtos;
using CleanArch.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Product.Queries
{
    public class GetProductQuery : IRequest<Response<ProductDto>>
    {
        public int Id { get; set; }
    }
}
