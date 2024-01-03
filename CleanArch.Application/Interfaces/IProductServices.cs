using CleanArch.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        //Task<ProductDTO> GetByIdAsync(int id);
        //Task AddAsync(ProductDTO product);
        //Task UpdateAsync(ProductDTO product);
        //Task RemoveAsync(int id);
    }
}
