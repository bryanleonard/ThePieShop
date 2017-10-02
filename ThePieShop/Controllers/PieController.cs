using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThePieShop.Models;
using ThePieShop.ViewModels;

namespace ThePieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            // version 1
            //ViewBag.CurrentCategory1 = "Not so sweet cakin cups.";
            //ViewData["CurrentCategory"] = "Sweet Cuppin' Cakes!";
            //return View(_pieRepository.Pies);

            //version 2
            //PiesListViewModel piesListViewModel = new PiesListViewModel();
            //piesListViewModel.Pies = _pieRepository.Pies;
            //piesListViewModel.CurrentCategory = "Sweet cuppin' cakes!";
            //return View(piesListViewModel);
            //throw new Exception("Error");
            //version 3
            IEnumerable<Pie> pies;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.Pies.OrderBy(p => p.PieId);
                currentCategory = "All spies";
            }
            else
            {
                category = category.ToLower();
                pies = _pieRepository.Pies.Where(p => p.Category.CategoryName.ToLower() == category)
                    .OrderBy(p => p.PieId);

                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName.ToLower() == category).CategoryName;
            }

            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }


        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }
    }
}