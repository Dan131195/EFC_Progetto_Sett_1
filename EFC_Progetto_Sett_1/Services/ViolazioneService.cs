using System.Collections.Generic;
using System.Linq;
using EFC_Progetto_Sett_1.Data;
using EFC_Progetto_Sett_1.Models;

namespace EFC_Progetto_Sett_1.Services
{
    public class ViolazioneService
    {
        private readonly ApplicationDbContext _context;

        public ViolazioneService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Violazione> GetAllViolazioni()
        {
            return _context.Violazioni.ToList();
        }

        public void AddViolazione(Violazione violazione)
        {
            _context.Violazioni.Add(violazione);
            _context.SaveChanges();
        }

        public Violazione GetViolazioneById(int id)
        {
            return _context.Violazioni.FirstOrDefault(v => v.Id == id);
        }
    }

}
