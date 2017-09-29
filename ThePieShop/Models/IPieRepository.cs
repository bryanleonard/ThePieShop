using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThePieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> Pies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }

        Pie GetPieById(int pieId);
    }
}
