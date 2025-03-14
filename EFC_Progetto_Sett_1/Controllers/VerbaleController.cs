using EFC_Progetto_Sett_1.Data;
using EFC_Progetto_Sett_1.Models;
using EFC_Progetto_Sett_1.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFC_Progetto_Sett_1.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VerbaleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewData["Trasgressori"] = new SelectList(_context.Trasgressori, "Id", "Nome");
            ViewData["Violazioni"] = new SelectList(_context.Violazioni, "Id", "Descrizione");
            return View();
        }

        [HttpPost]
        public IActionResult Create(VerbaleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var verbale = new Verbale
                {
                    TrasgressoreId = model.TrasgressoreId,
                    ViolazioneId = model.ViolazioneId,
                    DataViolazione = model.DataViolazione,
                    Importo = model.Importo,
                    PuntiDecurtati = model.PuntiDecurtati
                };

                _context.Verbali.Add(verbale);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }

}
