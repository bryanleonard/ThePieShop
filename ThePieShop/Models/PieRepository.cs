using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThePieShop.Data;

namespace ThePieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public PieRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> Pies
        {
            get
            {
                //load all pies and related categories
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                //load all pies and related category if pie is a pie of the week
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            //get pie by ID, duh
            //return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
            return _appDbContext.Pies.Include(p => p.PieReviews).FirstOrDefault(p => p.PieId == pieId);
        }

        public void UpdatePie(Pie pie)
        {
            _appDbContext.Pies.Update(pie);
            _appDbContext.SaveChanges();
        }

        public void CreatePie(Pie pie)
        {
            _appDbContext.Pies.Add(pie);
            _appDbContext.SaveChanges();
        }
    }
}
