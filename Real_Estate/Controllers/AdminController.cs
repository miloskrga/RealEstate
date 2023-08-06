using Microsoft.AspNetCore.Mvc;
using Real_Estate.Models;
using Real_Estate.ViewModels;
using Real_Estate.ViewModels.Data;
using Real_Estate.ViewModels.Repository;

namespace Real_Estate.Controllers
{
    public class AdminController : Controller
    {
        private readonly KorisnikRepository korisnikRepository;
        private readonly GradoviRepository gradoviRepository;
        private readonly MikrolokacijaRepository mikrolokacijaRepository;
        private readonly UlicaRepository ulicaRepository;
        private readonly AgencijaRepository agencijaRepository;
        private readonly NekretnineRepository nekretnineRepository;

        public AdminController(KorisnikRepository _korisnikRepository, GradoviRepository _gradoviRepository, MikrolokacijaRepository _mikrolokacijaRepository,
            UlicaRepository _ulicaRepository, AgencijaRepository _agencijaRepository, NekretnineRepository _nekretnineRepository)
        {
            korisnikRepository = _korisnikRepository;
            gradoviRepository = _gradoviRepository;
            mikrolokacijaRepository = _mikrolokacijaRepository;
            ulicaRepository = _ulicaRepository;
            agencijaRepository = _agencijaRepository;
            nekretnineRepository = _nekretnineRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PocetnaAdmin()
        {          
            ViewData["Gradovi"] = gradoviRepository.GetAllGradovi();
            return View();
        }
        [HttpPost]
        public IActionResult PocetnaAdmin(int? IdGrada, string tipKorisnika)
        {
            ViewData["Gradovi"] = gradoviRepository.GetAllGradovi();
            if(IdGrada != null && tipKorisnika != null)
            {
                List<Korisnik> korisnici = korisnikRepository.FindByIdTipKorisnikaIdGrada(IdGrada, tipKorisnika);
                return View(korisnici);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Agencije()
        {
            ViewData["Gradovi"] = gradoviRepository.GetAllGradovi();
            return View();
        }
        [HttpPost]
        public IActionResult Agencije(int idGrada)
        {
            ViewData["Gradovi"] = gradoviRepository.GetAllGradovi();
            List<Agencija> agencije = agencijaRepository.GetAllAgencija(idGrada);
            return View(agencije);
        }      
        [HttpGet]
        public IActionResult DodajAgenciju()
        {
            ViewBag.Gradovi = gradoviRepository.GetAllGradovi();
            return View();
        }
        [HttpPost]
        public IActionResult DodajAgenciju(Agencija agencija)
        {            
            string poruka = AgencijaViewModel.ProveraAgencije(agencija);
            if (poruka=="Ok")
            {
                agencijaRepository.AddAgenciju(agencija);
            }
            ViewBag.Gradovi = gradoviRepository.GetAllGradovi();
            return RedirectToAction("Agencije");
        }
        [HttpGet]
        public IActionResult UrediAgenciju(int IdAgencije)//stranica za promenu podataka(edit)
        {
            ViewBag.Gradovi = gradoviRepository.GetAllGradovi();
            Agencija agencija = agencijaRepository.FindById(IdAgencije);
            return View(agencija);
        }
        [HttpPost]
        public IActionResult UrediAgenciju(Agencija agencija)//stranica za promenu podataka(edit) o agenciji
        {
            
            string poruka = AgencijaViewModel.ProveraAgencije(agencija);
            if (poruka == "Ok")
            {
                agencijaRepository.UpdateAgencija(agencija);
                ViewBag.Gradovi = gradoviRepository.GetAllGradovi();
                return View("Agencije");
            }
            else
            {
                ViewBag.Poruka = poruka;
            }
            ViewBag.Gradovi = gradoviRepository.GetAllGradovi();
            return View("Agencije");
        }
        [HttpPost]
        public IActionResult BrisiAgenciju(int IdAgencije)
        {
            agencijaRepository.DeleteAgenciju(IdAgencije);
            return RedirectToAction("Agencije");
        }

        [HttpGet]
        public IActionResult Mikrolokacije()
        {
            ViewData["Gradovi"] = gradoviRepository.GetAllGradovi();           
            return View();
        }
        [HttpPost]
        public IActionResult Mikrolokacije(int idopstine)
        {
            ViewData["Gradovi"] = gradoviRepository.GetAllGradovi();           
            List<Mikrolokacija> mikrolokacije = mikrolokacijaRepository.GetAllMikrolokacija(idopstine);
            return View(mikrolokacije);
        }
        [HttpPost]
        public IActionResult BrisiMikrolokaciju(int IdMikrolokacije)
        {
            mikrolokacijaRepository.DeleteMikrolokacija(IdMikrolokacije);
            return RedirectToAction("Mikrolokacije");
        }
        [HttpGet]
        public IActionResult DodajMikrolokacije()
        {
            ViewBag.Gradovi = gradoviRepository.GetAllGradovi();
            return View();
        }
        [HttpPost]
        public IActionResult DodajMikrolokacije(Mikrolokacija mikrolokacija)
        {
            if(mikrolokacija.NazivMikrolokacije !=null && mikrolokacija.IdOpstine != null)
            {
                mikrolokacijaRepository.AddMikrolokacija(mikrolokacija);
            }
            ViewBag.Gradovi = gradoviRepository.GetAllGradovi();
            return RedirectToAction("Mikrolokacije");
        }
        [HttpGet]
        public IActionResult Ulice()
        {
            ViewData["Gradovi"] = gradoviRepository.GetAllGradovi();
            return View();
        }
        [HttpPost]
        public IActionResult Ulice(int idmikrolokacije)
        {
            ViewData["Gradovi"] = gradoviRepository.GetAllGradovi();
            List<Ulica> ulice = ulicaRepository.GetAllUlica(idmikrolokacije);
            return View(ulice);
        }
        [HttpPost]
        public IActionResult BrisiUlicu(int IdUlice)
        {
            ulicaRepository.DeleteUlica(IdUlice);
            return RedirectToAction("Ulice");
        }
        [HttpGet]
        public IActionResult DodajUlicu()
        {
            ViewBag.Gradovi = gradoviRepository.GetAllGradovi();
            return View();
        }
        [HttpPost]
        public IActionResult DodajUlicu(Ulica ulica)
        {
            if (ulica.NazivUlice != null && ulica.IdMikrolokacije != null)
            {
                ulicaRepository.AddUlica(ulica);
            }
            ViewBag.Gradovi = gradoviRepository.GetAllGradovi();
            return RedirectToAction("Ulice");
        }
        [HttpGet]
        public IActionResult ProdateNekretnine()// grad i opstina, tip nekretnine
        {
            ViewBag.Gradovi = gradoviRepository.GetAllGradovi();
            return View();
        }

        [HttpPost]
        public IActionResult ProdateNekretnine(int IdOpstine, string tipStanja , string tipNekretnine)
        {
            //nije dovrseno FindNekretnineByIdOpstine u NekretnineRepository

            if (IdOpstine !=null && tipStanja!=null && tipNekretnine != null)
            {
                List<Nekretnine> nekretnine=nekretnineRepository.FindNekretnineByIdOpstine(IdOpstine, tipStanja, tipNekretnine);
                return View(nekretnine);
            }
            return View();
        }
    }
}
