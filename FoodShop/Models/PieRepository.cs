using Microsoft.EntityFrameworkCore;

namespace FoodShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly FoodShopDbContext _foodShopDbContext;

        public PieRepository(FoodShopDbContext foodShopDbContext)
        {
            _foodShopDbContext = foodShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _foodShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _foodShopDbContext.Pies.Include(c => c.Category).Where(p=>p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById (int pieId)
        {
            return _foodShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _foodShopDbContext.Pies.Where(pie => pie.Name.Contains(searchQuery));
        }
    }
}
