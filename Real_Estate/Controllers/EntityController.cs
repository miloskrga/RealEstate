using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Models;
using Real_Estate.Models.Enums;
using Real_Estate.ViewModels;
using Real_Estate.ViewModels.Data;
using Real_Estate.ViewModels.Repository;

namespace Real_Estate.Controllers
{
    public class EntityController : Controller
    {
        private readonly AppDbContext context;
        private readonly AgencijaRepository agencijaRepository;
        private readonly KorisnikRepository korisnikRepository;

        public EntityController(AppDbContext _context, AgencijaRepository _agencijaRepository, KorisnikRepository _korisnikRepository)
        {
            context = _context;
            agencijaRepository = _agencijaRepository;
            korisnikRepository = _korisnikRepository;
        }
        public IActionResult Index()
        {         
            return View();
        }


        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(Korisnik korisnik)
        {
            Korisnik korisnik1 = korisnikRepository.FindByEmail(korisnik.Email);
            if (korisnik1!=null && korisnik1.Password==korisnik.Password )
            {
                HttpContext.Session.SetInt32("idkorisnika", korisnik1.IdKorisnika);
                if (korisnik1.IdTipKorisnika == TipKorisnika.Owner)
                {
                    return RedirectToAction("PocetnaProdavac", "Nekretnine");
                }
                else if(korisnik1.IdTipKorisnika == TipKorisnika.Customer)
                {
                    return RedirectToAction("PocetnaProdavac", "Nekretnine");//korisnik pocetna
                }
                else if (korisnik1.IdTipKorisnika == TipKorisnika.Admin)
                {
                    return RedirectToAction("PocetnaAdmin", "Admin");//admin sranica
                }
                else
                {
                    return View("LogIn");
                }
            }
            else
            {
                ViewBag.Poruka = "Email ili Password nisu validni";
                return View("LogIn");
            }   
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("LogIn");
        }

        [HttpGet]
        public IActionResult Registracija()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registracija(Korisnik korisnik)
        {
            if (korisnikRepository.FindByUserName(korisnik.Username) != null)
            {
                ViewBag.Poruka = "Korisnik sa datim UserName-om vec postoji";
                return View("Registracija");
            }

            string poruka=KorisnikViewModel.ProveraKorisnika(korisnik);
           
            if (poruka == "Ok")
            {
                if(korisnik.IdTipKorisnika==TipKorisnika.Owner && agencijaRepository.FindById(korisnik.IdAgencije)==null)
                {
                    ViewBag.Poruka = "Agencija sa datim Id-em ne postoji";
                    return View("Registracija");
                }

                korisnikRepository.AddUser(korisnik);
                return View("LogIn");
            }
            else
            {
                ViewBag.Poruka = poruka;
            }
            return View("Registracija");
        }

        [HttpGet]
        public IActionResult Profil()
        {
            int id = (int)HttpContext.Session.GetInt32("idkorisnika");
            Korisnik korisnik = korisnikRepository.FindById(id);
            return View(korisnik);
        }

        [HttpGet]
        public IActionResult UrediProfil()
        {
            int id = (int)HttpContext.Session.GetInt32("idkorisnika");
            Korisnik korisnik = korisnikRepository.FindById(id);
            return View(korisnik);
        }

        [HttpPost]
        public IActionResult UrediProfil(Korisnik korisnik)
        {
            int id = (int)HttpContext.Session.GetInt32("idkorisnika");
            string poruka = KorisnikViewModel.ProveraKorisnika(korisnik);

            if (poruka == "Ok")
            {
                if (korisnik.IdTipKorisnika == TipKorisnika.Owner && agencijaRepository.FindById(korisnik.IdAgencije) == null)
                {
                    ViewBag.Poruka = "Agencija sa datim Id-em ne postoji";
                    return View("Profil");
                }

                korisnikRepository.UpdateUser(korisnik);
                return View("Profil",korisnik);
            }
            else
            {
                ViewBag.Poruka = poruka;
            }

            return View("Profil",korisnikRepository.FindById(id));
        }

    }
}
