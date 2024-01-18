namespace FoodShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FoodShopDbContext _foodShopDbContext;

        public CategoryRepository(FoodShopDbContext foodShopDbContext)
        {
            _foodShopDbContext = foodShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _foodShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
