using EFC_Progetto_Sett_1.Models;

namespace EFC_Progetto_Sett_1.ViewModels
{
    public class ReportViewModel
    {
        public IEnumerable<Trasgressore> Trasgressori { get; set; }
        public IEnumerable<Verbale> VerbaliHighPoints { get; set; }
        public IEnumerable<Verbale> VerbaliHighImporto { get; set; }
    }
}
