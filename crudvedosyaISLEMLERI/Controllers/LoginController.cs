using crudvedosyaISLEMLERI.Models;
using crudvedosyaISLEMLERI.Models.Baglanti;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MerleTur.Controllers
{
    public class LoginController : Controller
    {
        private readonly DbBaglantisi _context;

        public LoginController(DbBaglantisi context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            // Veritabanından kullanıcıyı çek
            var kullanici = _context.Loginler.FirstOrDefault(k => k.KullaniciAdi == login.KullaniciAdi && k.Sifre == login.Sifre);

            if (kullanici != null)
            {
                // Rol kontrolü
                if (kullanici.Rol == "admin")
                {
                    return RedirectToAction("Index", "Sarkici"); 
                }
                else
                {
                    return RedirectToAction("Index", "Home"); 
                }
            }

            ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }
    }
}
