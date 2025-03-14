using EFC_Progetto_Sett_1.Data;
using EFC_Progetto_Sett_1.Models;
using EFC_Progetto_Sett_1.Services;
using EFC_Progetto_Sett_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFC_Progetto_Sett_1.Controllers
{
    public class TrasgressoreController : Controller
    {
        private readonly TrasgressoreService _trasgressoreService; // Usa il servizio invece di _context

        public TrasgressoreController(ApplicationDbContext context)
        {
            _trasgressoreService = new TrasgressoreService(context); // Inizializza il servizio con il contesto
        }

        public IActionResult Index()
        {
            var trasgressori = _trasgressoreService.GetAllTrasgressori(); // Recupera i trasgressori dal servizio
            return View(trasgressori); // Passa la lista alla vista
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TrasgressoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var trasgressore = new Trasgressore
                {
                    Nome = model.Nome,
                    Cognome = model.Cognome,
                    Indirizzo = model.Indirizzo,
                    Telefono = model.Telefono,
                    DataRegistrazione = DateTime.Now
                };

                _trasgressoreService.AddTrasgressore(trasgressore); // Usa il servizio per aggiungere il trasgressore
                return RedirectToAction("Index"); // Torna alla lista
            }
            return View(model);
        }
    }
}
