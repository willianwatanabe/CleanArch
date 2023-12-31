using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productEntities = await _productRepository.GetProductsAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(productEntities);
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
