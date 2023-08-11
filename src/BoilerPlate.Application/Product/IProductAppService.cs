using Abp.Application.Services;
using BoilerPlate.Product.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoilerPlate.Product
{
    public interface IProductAppService : IAsyncCrudAppService<ProductDto, int, CreateProductDto, ProductDto>
    {
        Task<List<ProductDto>> GetProductAsync();
        Task UpdateProductAsync(ProductDto input);
        Task<ProductDto> GetProductByIdAsync(int id);

        Task DeleteAsync(int id);


    }
}
