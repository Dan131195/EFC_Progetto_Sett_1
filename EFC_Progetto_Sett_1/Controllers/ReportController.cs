using EFC_Progetto_Sett_1.Data;
using EFC_Progetto_Sett_1.Services;
using EFC_Progetto_Sett_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFC_Progetto_Sett_1.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly VerbaleService _verbaleService;

        public ReportController(ApplicationDbContext context, VerbaleService verbaleService)
        {
            _context = context;
            _verbaleService = verbaleService;
        }

        public IActionResult Index()
        {
            var model = new ReportViewModel
            {
                Trasgressori = _context.Trasgressori.Include(t => t.Verbali).ToList(),
              
                VerbaliHighPoints = _verbaleService.GetVerbaliWithHighPoints(),

                VerbaliHighImporto = _verbaleService.GetVerbaliWithHighImporto()
            };

            return View(model);
        }
    }
}
