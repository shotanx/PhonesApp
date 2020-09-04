using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Phones.Data;
using Phones.Models;

namespace Phones.Controllers
{
    public class HomeController : Controller
    {
        private readonly PhonesContext _context;

        public HomeController(PhonesContext context)
        {
            _context = context;
        }

        // GET: Phones
        public async Task<IActionResult> Index(PhoneSearchModel searchModel)
        {
            var business = new PhoneBusinessLogic(_context);
            var model = business.GetProducts(searchModel);

            ViewData["PriceSortParm"] = searchModel.SortByPrice;
            ViewData["NameSortParm"] = searchModel.SortByName;
            ViewData["CurrentSortParm"] = searchModel.CurrentSort;

            ViewData["NameFilter"] = searchModel.FilterByName;

            ViewData["PriceFromFilter"] = searchModel.FilterByPriceFrom;


            //ViewData["PriceSortParm"] = string.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            //ViewData["PriceSortParmNot"] = 
            //    string.IsNullOrEmpty(sortOrder) ? "" : "price_desc"; // sachiroa rata sortirebam da filtraciam ertdroulad imushaos
            //ViewData["CurrentFilter"] = searchString;

            //var phones = _context.Phones.Include(p => p.Producer);

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    phones = phones.Where(p => p.Name.Contains(searchString))
            //        .Include(p => p.Producer);
            //}

            //if (sortOrder == "price_desc")
            //{
            //    phones = phones.OrderByDescending(p => p.Price).Include(p => p.Producer);
            //}
            //else
            //{
            //    phones = phones.OrderBy(p => p.Price).Include(p => p.Producer);
            //}




            //return View(await phones.ToListAsync());
            //return ((IActionResult)model);
            return View(await PaginatedList<Phone>.CreateAsync(model, searchModel));
        }

        // GET: Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.Producer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
