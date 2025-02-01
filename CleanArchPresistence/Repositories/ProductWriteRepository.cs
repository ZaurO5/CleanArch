using CleanArch.Domain.Repositories;
using CleanArch.Presistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Presistence.Repositories
{
    public class ProductWriteRepository : BaseWriteRepository<CleanArch.Domain.Entities.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(AppDbContext context) : base(context)
        {

        }
    }
}
