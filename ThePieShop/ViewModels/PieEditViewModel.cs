﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThePieShop.Models;

namespace ThePieShop.ViewModels
{
    public class PieEditViewModel
    {
        public Pie Pie { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public int CategoryId { get; set; }
    }
}
