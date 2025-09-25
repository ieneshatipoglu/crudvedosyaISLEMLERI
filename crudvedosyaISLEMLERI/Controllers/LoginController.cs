using crudvedosyaISLEMLERI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerleTur.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (login.KullaniciAdi == "admin" && login.Sifre == "admin")
            {
                // Giriş başarılı -> Ana sayfaya yönlendir
                return RedirectToAction("Index", "Sarkici");
            }
             

            // Hata varsa ViewBag ile uyarı gönder
            ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }
    }
}
