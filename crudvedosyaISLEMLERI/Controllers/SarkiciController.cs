using Microsoft.AspNetCore.Mvc;
using crudvedosyaISLEMLERI.Models;
using crudvedosyaISLEMLERI.Models.Baglanti;
using crudvedosyaISLEMLERI.Models.BuKlasorrr;

namespace crudvedosyaISLEMLERI.Controllers
{
    public class SarkiciController : Controller
    {
        private readonly DbBaglantisi _context;
        private readonly IWebHostEnvironment _env;

        public SarkiciController(DbBaglantisi context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
          
            {
                var vm = new Sinifsal
                {
                    Sarkilar = _context.Sarkilar.ToList(),
                    Dosyalar = _context.Dosyalar.ToList()
                };
                return View(vm);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sarki sarki, IFormFile dosya)
        {
            if (!ModelState.IsValid)
                return View(sarki);

            
            _context.Sarkilar.Add(sarki);
            _context.SaveChanges(); 

            
            if (dosya != null && dosya.Length > 0)
            {
                var izinliTurler = new string[] {".jpg", ".png", ".pdf" };
                var uzanti = Path.GetExtension(dosya.FileName)?.ToLower() ?? "";

                if (!izinliTurler.Contains(uzanti))
                {
                    TempData["Mesaj"] = "Sadece .jpg, .png, .pdf dosyaları yüklenebilir.";
                    return RedirectToAction("Index");
                }

                var uploads = Path.Combine(_env.WebRootPath, "Images");
                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                var dosyaAdi = Guid.NewGuid().ToString() + uzanti;
                var dosyaYolu = Path.Combine(uploads, dosyaAdi);

                using (var stream = new FileStream(dosyaYolu, FileMode.Create))
                {
                    dosya.CopyTo(stream);
                }

                var kayit = new Dosya
                {
                    Ad = dosya.FileName,
                    Boyut = dosya.Length,
                    Tip = uzanti.StartsWith(".") ? uzanti.Substring(1) : uzanti
                };

                _context.Dosyalar.Add(kayit);
                _context.SaveChanges();
            }

            TempData["Mesaj"] = "✅ Şarkı ve dosya başarıyla kaydedildi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var sarki = _context.Sarkilar.Find(id);
            return View(sarki);
        }

        [HttpPost]
        public IActionResult Update(Sarki sarki)
        {
            if (!ModelState.IsValid)
                return View(sarki);

            _context.Sarkilar.Update(sarki);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var sarki = _context.Sarkilar.Find(id);
            if (sarki != null)
            {
                _context.Sarkilar.Remove(sarki);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
