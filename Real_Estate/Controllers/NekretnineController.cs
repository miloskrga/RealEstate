using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Models;
using Real_Estate.ViewModels.Data;
using Real_Estate.ViewModels.Repository;

namespace Real_Estate.Controllers
{
    public class NekretnineController : Controller
    {
        private readonly NekretnineRepository nekretnineRepository;
        private readonly OpstinaRepository opstinaRepository;
        private readonly GradoviRepository gradoviRepository;
        private readonly MikrolokacijaRepository mikrolokacijaRepository;
        private readonly UlicaRepository ulicaRepository;

        public NekretnineController(NekretnineRepository _nekretnineRepository, OpstinaRepository _opstinaRepository, 
            GradoviRepository _gradoviRepository, MikrolokacijaRepository _mikrolokacijaRepository, UlicaRepository _ulicaRepository)
        {
            nekretnineRepository = _nekretnineRepository;
            opstinaRepository = _opstinaRepository;
            gradoviRepository = _gradoviRepository;
            mikrolokacijaRepository = _mikrolokacijaRepository;
            ulicaRepository = _ulicaRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PocetnaProdavac()
        {           
            int id= (int)HttpContext.Session.GetInt32("idkorisnika");
            List<Nekretnine> nekretnine= nekretnineRepository.FindNekretnineByProdavac(id);
            return View("PocetnaProdavac",nekretnine);
        }

        [HttpGet]
        public IActionResult NovaNekretnina()
        {
            ViewBag.Gradovi= gradoviRepository.GetAllGradovi();
            return View();
        }
        public JsonResult GetOpstinaByGrad(int cityId)
        {
            List<Opstina> opstine = opstinaRepository.GetAllOpstina(cityId);
            return Json(opstine);
        }
        public JsonResult GetMikrolokacijaByOpstina(int opstinaId)
        {
            List<Mikrolokacija> mikrolokacije = mikrolokacijaRepository.GetAllMikrolokacija(opstinaId);
            return Json(mikrolokacije);
        }
        public JsonResult GetUlicaByMikrolokacija(int mikrolokacijaId)
        {
            List<Ulica> ulice = ulicaRepository.GetAllUlica(mikrolokacijaId);
            return Json(ulice);
        }
        

        [HttpPost]
        public IActionResult NovaNekretnina(Nekretnine nekretnine)
        {
            int id = (int)HttpContext.Session.GetInt32("idkorisnika");
            return View();
        }
    }
}
