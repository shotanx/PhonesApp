using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phones.BusinessLogic;
using Phones.Data;
using Phones.Models;

namespace Phones.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDatabaseAccess _assets;

        public HomeController(IDatabaseAccess assets)
        {
            _assets = assets;
        }

        // GET: Phones
        public async Task<IActionResult> Index(PhoneSearchModel searchModel)
        {
            var business = new PhoneBusinessLogic(_assets);
            var model = await business.GetProductsAsync(searchModel);

            ViewData["PriceSortParm"] = searchModel.SortByPrice;
            ViewData["NameSortParm"] = searchModel.SortByName;
            ViewData["CurrentSortParm"] = searchModel.CurrentSort;

            ViewData["NameFilter"] = searchModel.FilterByName;

            ViewData["PriceFromFilter"] = searchModel.FilterByPriceFrom;
            ViewData["PriceToFilter"] = searchModel.FilterByPriceTo;

            ViewData["ProducerNameFilter"] = searchModel.FilterByProducerName;
            ViewBag.ProducerNamesDropdown = searchModel.ProducerNamesDropdown;


            return View(model);
        }

        // GET: Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _assets.GetPhoneByIdAsync((int)id);

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
