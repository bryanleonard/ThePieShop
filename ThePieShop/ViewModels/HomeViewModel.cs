using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThePieShop.Models;

namespace ThePieShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
    }
}
