using Microsoft.EntityFrameworkCore;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Repository.Implementation
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(PlushDbContext plushDbContext) : base(plushDbContext)
        {

        }

        public override async Task<IEnumerable<Product>> GetItemsAsync()
        {
            return await _context.Set<Product>()
                            .Include("Provider")
                            .Include("Category")
                            .ToListAsync();
        }
    }
}
