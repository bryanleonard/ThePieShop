using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThePieShop.Models;
using ThePieShop.ViewModels;
using System.Text.Encodings.Web;

namespace ThePieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPieReviewRepository _pieReviewRepository;
        private readonly HtmlEncoder _htmlEncoder;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository,
            IPieReviewRepository pieReviewRepository, HtmlEncoder htmlEncoder)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            _pieReviewRepository = pieReviewRepository;
            _htmlEncoder = htmlEncoder;
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



        [Route("[controller]/Details/{id}")]
        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(new PieDetailViewModel() { Pie = pie });
        }

        [Route("[controller]/Details/{id}")]
        [HttpPost]
        public IActionResult Details(int id, string review)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }

            //_pieReviewRepository.AddPieReview(new PieReview() { Pie = pie, Review = review });
            string encodedReview = _htmlEncoder.Encode(review);
            _pieReviewRepository.AddPieReview(new PieReview() { Pie = pie, Review = encodedReview });

            ModelState.Clear(); // just emptying out the review form field.

            return View(new PieDetailViewModel() { Pie = pie });
        }

    }
}