using Plush.ApplicationLogger;
using Plush.BusinessLogicLayer.Repository.Implementation;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly PlushDbContext context;
        private ICategoryRepository categoryRepository;
        private IDeliveryRepository deliveryRepository;
        private IProviderRepository providerRepository;
        private IProductRepository productRepository;
        private IImageRepository imageRepository;
        private IUserRepository userRepository;
        private IWishlistRepository wishlistRepository;
        private readonly ILoggerService _loggerService;
        public UnitOfWork(PlushDbContext ctx, ILoggerService loggerService)
        {
            context = ctx;
            _loggerService = loggerService;
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository(context, _loggerService);
                }

                return categoryRepository;
            }
        }
        public IDeliveryRepository DeliveryRepository
        {
            get
            {
                if (deliveryRepository == null)
                {
                    deliveryRepository = new DeliveryRepository(context, _loggerService);
                }

                return deliveryRepository;
            }
        }
        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(context, _loggerService);
                }

                return productRepository;
            }
        }
        public IProviderRepository ProviderRepository
        {
            get
            {
                if (providerRepository == null)
                {
                    providerRepository = new ProviderRepository(context, _loggerService);
                }

                return providerRepository;
            }
        }
        public IImageRepository ImageRepository
        {
            get
            {
                if (imageRepository == null)
                {
                    imageRepository = new ImageRepository(context, _loggerService);
                }

                return imageRepository;
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context, _loggerService);
                }

                return userRepository;
            }
        }
        public IWishlistRepository WishlistRepository
        {
            get
            {
                if (wishlistRepository == null)
                {
                    wishlistRepository = new WishlistRepository(context, _loggerService);
                }

                return wishlistRepository;
            }
        }
        public async Task<bool> CommitAsync(string loggDetails)
        {
            try
            {
                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(loggDetails, ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    _loggerService.LogError(loggDetails, ex.InnerException.Message);
                }
                Dispose();
            }

            return false;
        }

        public async void Dispose()
        {
            await context.DisposeAsync();
        }
    }
}
