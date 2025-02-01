using AutoMapper;
using CleanArch.Application.Exceptions;
using CleanArch.Application.Features.Product.Dtos;
using CleanArch.Application.Wrappers;
using CleanArch.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Features.Product.Queries
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, Response<ProductDto>>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public GetProductHandler(IProductReadRepository productReadRepository,
                                 IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }
        public async Task<Response<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetAsync(request.Id);
            if (product is null)
                throw new NotFoundException("Product is not found");

            return new Response<ProductDto>
            {
                Data = _mapper.Map<ProductDto>(product)
            };
        }
    }
}
