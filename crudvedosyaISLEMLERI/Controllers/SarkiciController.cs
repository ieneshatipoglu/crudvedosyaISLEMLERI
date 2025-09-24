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
    }
}
