
using System.Collections.Generic;
using System.Linq;
using EFC_Progetto_Sett_1.Data;
using EFC_Progetto_Sett_1.Models;
using Microsoft.EntityFrameworkCore;

namespace EFC_Progetto_Sett_1.Services
{
    public class VerbaleService
    {
        private readonly ApplicationDbContext _context;

        public VerbaleService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Aggiunge un nuovo verbale
        public void AddVerbale(Verbale verbale)
        {
            _context.Verbali.Add(verbale);
            _context.SaveChanges();
        }

        // Recupera tutti i verbali, includendo i dati relativi a trasgressore e violazione
        public List<Verbale> GetAllVerbali()
        {
            return _context.Verbali
                           .Include(v => v.Trasgressore)
                           .Include(v => v.Violazione)
                           .ToList();
        }

        // Restituisce statistiche raggruppate per trasgressore: numero di verbali e somma dei punti decurtati
        public Dictionary<int, (int Count, int TotalPoints)> GetStatisticheVerbaliPerTrasgressore()
        {
            return _context.Verbali
                           .GroupBy(v => v.TrasgressoreId)
                           .Select(g => new { TrasgressoreId = g.Key, Count = g.Count(), TotalPoints = g.Sum(v => v.PuntiDecurtati) })
                           .ToDictionary(x => x.TrasgressoreId, x => (x.Count, x.TotalPoints));
        }

        // Filtra i verbali relativi a violazioni con punti decurtati superiori a 10
        public List<Verbale> GetVerbaliWithHighPoints()
        {
            return _context.Verbali
                           .Include(v => v.Violazione)
                           .Where(v => v.Violazione.PuntiDecurtati > 10)
                           .ToList();
        }

        // Filtra i verbali relativi a violazioni con importo maggiore di 400 euro
        public List<Verbale> GetVerbaliWithHighImporto()
        {
            return _context.Verbali
                           .Include(v => v.Violazione)
                           .Where(v => v.Violazione.Importo > 400)
                           .ToList();
        }
    }

}
