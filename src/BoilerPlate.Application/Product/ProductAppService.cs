using Abp.Application.Services;
using Abp.Domain.Repositories;
using BoilerPlate.Authorization.Product;
using BoilerPlate.Authorization.Roles;
using BoilerPlate.Authorization.Users;
using BoilerPlate.Product.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoilerPlate.Product
{

    public class ProductAppService : AsyncCrudAppService<MyProduct, ProductDto, int, CreateProductDto>, IProductAppService
    {
        private readonly IRepository<MyProduct, int> _productRepository;
        private readonly RoleManager _roleManager;
        private readonly ProductManager _productManager;
        private readonly UserManager _userManager;

        public ProductAppService(IRepository<MyProduct, int> productRepository, UserManager userManager, RoleManager roleManager, ProductManager productManager)
           : base(productRepository)
        {
            _productRepository = productRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _productManager = productManager;
        }


        public async Task CreatepAsync(CreateProductDto input)
        {
            var product = ObjectMapper.Map<MyProduct>(input);
            product.CreatedDate = DateTime.Now;
            product.ModifiedDate = DateTime.Now;
            await _productRepository.InsertAsync(product);

            await CurrentUnitOfWork.SaveChangesAsync();

        }

        public async Task<List<ProductDto>> GetProductAsync()
        {
            // Retrieve a list of MyProduct objects asynchronously from the repository
            List<MyProduct> products = await _productRepository.GetAllListAsync();

            // Map the MyProduct objects to ProductDto objects using ObjectMapper
            List<ProductDto> productDtos = ObjectMapper.Map<List<ProductDto>>(products);

            // Return the list of ProductDto objects
            return productDtos;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {


            var product = _productRepository.FirstOrDefault(x => x.Id == id);
            var pro = new ProductDto()
            {
                Id = product.Id,
                Description = product.Description,
                Price = product.Price,
                CreatedDate = product.CreatedDate,
                ModifiedDate = product.ModifiedDate,
                ProductName = product.ProductName,
            };
            return pro;
        }

        public async Task UpdateProductAsync(ProductDto input)
        {
            var product = _productRepository.FirstOrDefault(x => x.Id == input.Id);

            if (product != null)
            {
                product.Description = input.Description;
                product.Price = input.Price;

                product.ModifiedDate = DateTime.Now;
                product.ProductName = input.ProductName;

                await _productRepository.UpdateAsync(product);
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _productRepository.FirstOrDefaultAsync(id);
            if (product != null)
            {
                await _productRepository.DeleteAsync(product);
                await CurrentUnitOfWork.SaveChangesAsync();
           
            }

            else
            {
                throw new ApplicationException("Product not found.");
            }
        }

    }
}

