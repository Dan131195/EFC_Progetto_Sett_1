using EFC_Progetto_Sett_1.Data;
using EFC_Progetto_Sett_1.Models;
using EFC_Progetto_Sett_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFC_Progetto_Sett_1.Controllers
{
    public class TrasgressoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrasgressoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
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

                _context.Trasgressori.Add(trasgressore);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
