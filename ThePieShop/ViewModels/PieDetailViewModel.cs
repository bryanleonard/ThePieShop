using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThePieShop.Models;

namespace ThePieShop.ViewModels
{
    public class PieDetailViewModel
    {
        public Pie Pie { get; set; }
        public string Review { get; set; }
        public List<string> AllReviews { get; set; }
    }
}
