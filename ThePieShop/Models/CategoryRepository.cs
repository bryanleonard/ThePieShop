using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThePieShop.Data;

namespace ThePieShop.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public CategoryRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // return list of all categories
        public IEnumerable<Category> Categories => _appDbContext.Categories;
    }
}
