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

        public void AddTrasgressore(Trasgressore trasgressore)
        {
            _context.Trasgressori.Add(trasgressore);
            _context.SaveChanges();
        }

        public List<Trasgressore> GetAllTrasgressori()
        {
            return _context.Trasgressori.ToList();
        }

        public Trasgressore GetTrasgressoreById(int id)
        {
            return _context.Trasgressori.FirstOrDefault(t => t.Id == id);
        }
    }

}
