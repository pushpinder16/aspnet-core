using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using BoilerPlate.Authorization.Users;

namespace BoilerPlate.Authorization.Product
{
    public class ProductManager : DomainService
    {
        public IUnitOfWorkManager UnitOfWorkManager { get; set; }
        public IRepository<MyProduct, int> ProductRepository { get; set; }
        public IRepository<User, long> UserRepository { get; set; }
        public UserManager UserManager { get; set; }
        public IAbpSession AbpSession { get; set; }

        public ProductManager(
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<MyProduct, int> productRepository,
            IRepository<User, long> userRepository,
            UserManager userManager,
            IAbpSession abpSession)
        {
            UnitOfWorkManager = unitOfWorkManager;
            ProductRepository = productRepository;
            UserRepository = userRepository;
            UserManager = userManager;
            AbpSession = abpSession;

        }




    }
}
