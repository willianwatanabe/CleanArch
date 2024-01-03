using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public ProductServices(IProductRepository productRepository, IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            //var productEntities = await _productRepository.GetProductsAsync();

            //return _mapper.Map<IEnumerable<ProductDTO>>(productEntities);

            var productQuery = new GetProductsQuery();

            var result = await _mediator.Send(productQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task AddAsync(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);

            await _productRepository.CreateAsync(productEntity);
        }

        public async Task RemoveAsync(int id)
        {
            var productEntity = _productRepository.GetByIdAsync(id).Result;

            await _productRepository.RemoveAsync(productEntity);
        }

        public async Task UpdateAsync(ProductDTO product)
        {
            var productEntity = _mapper.Map<Product>(product);

            await _productRepository.UpdateAsync(productEntity);
        }
    }
}
