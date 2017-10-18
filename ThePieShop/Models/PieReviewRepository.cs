using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThePieShop.Data;

namespace ThePieShop.Models
{
    public class PieReviewRepository: IPieReviewRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public PieReviewRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddPieReview(PieReview pieReview)
        {
            _appDbContext.PieReviews.Add(pieReview);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<PieReview> GetReviewsForPie(int pieId)
        {
            return _appDbContext.PieReviews.Where(p => p.Pie.PieId == pieId);
            
        }


        public IEnumerable<PieReview> AllReviews => _appDbContext.PieReviews.ToList();
        
    }
}
