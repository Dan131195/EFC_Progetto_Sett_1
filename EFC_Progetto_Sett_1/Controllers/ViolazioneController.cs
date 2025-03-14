using EFC_Progetto_Sett_1.Data;
using EFC_Progetto_Sett_1.Models;
using EFC_Progetto_Sett_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFC_Progetto_Sett_1.Controllers
{
    public class ViolazioneController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ViolazioneController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var violazioni = _context.Violazioni.ToList();
            return View(violazioni);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ViolazioneViewModel violazioneViewModel)
        {
            if (ModelState.IsValid)
            {
                var violazione = new Violazione
                {
                    Descrizione = violazioneViewModel.Descrizione,
                    PuntiDecurtati= violazioneViewModel.PuntiDecurtati,
                    Importo = violazioneViewModel.Importo
                };

                _context.Violazioni.Add(violazione);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(violazioneViewModel);
        }
    }
}
