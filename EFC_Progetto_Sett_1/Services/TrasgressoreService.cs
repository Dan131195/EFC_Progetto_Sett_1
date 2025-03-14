using System.Collections.Generic;
using System.Linq;
using EFC_Progetto_Sett_1.Data;
using EFC_Progetto_Sett_1.Models;

namespace EFC_Progetto_Sett_1.Services
{
    public class TrasgressoreService
    {
        private readonly ApplicationDbContext _context;

        public TrasgressoreService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Aggiunge un nuovo trasgressore
        public void AddTrasgressore(Trasgressore trasgressore)
        {
            _context.Trasgressori.Add(trasgressore);
            _context.SaveChanges();
        }

        // Recupera tutti i trasgressori
        public List<Trasgressore> GetAllTrasgressori()
        {
            return _context.Trasgressori.ToList();
        }

        // Recupera un trasgressore per Id
        public Trasgressore GetTrasgressoreById(int id)
        {
            return _context.Trasgressori.FirstOrDefault(t => t.Id == id);
        }
    }

}
