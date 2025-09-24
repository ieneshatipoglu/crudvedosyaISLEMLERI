using Microsoft.AspNetCore.Mvc;
using crudvedosyaISLEMLERI.Models;
using crudvedosyaISLEMLERI.Models.Baglanti;

namespace crudvedosyaISLEMLERI.Controllers
{
    public class SarkiciController : Controller
    {
        private readonly DbBaglantisi _context;
        public SarkiciController(DbBaglantisi context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sarkilar=_context.Sarkilar.ToList();
            return View(sarkilar);
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sarki sarkilar)
        {
            _context.Sarkilar.Add(sarkilar);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
