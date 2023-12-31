using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }


        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);

            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoryEntities = await _categoryRepository.GetCategoriesAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntities);
        }

        public async Task AddAsync(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);

            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task RemoveAsync(int id)
        {
            var categoryEntity = _categoryRepository.GetByIdAsync(id).Result;

            await _categoryRepository.RemoveAsync(categoryEntity);
        }

        public async Task UpdateAsync(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);

            await _categoryRepository.UpdateAsync(categoryEntity);
        }
    }
}
