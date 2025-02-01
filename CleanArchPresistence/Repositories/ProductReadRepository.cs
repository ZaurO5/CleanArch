using CleanArch.Domain.Repositories;
using CleanArch.Presistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Presistence.Repositories
{
    public class ProductReadRepository : BaseReadRepository<CleanArch.Domain.Entities.Product>, IProductReadRepository
    {
        private readonly AppDbContext _context;

        public ProductReadRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CleanArch.Domain.Entities.Product> GetByNameAsync(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
        }
    }
}
