namespace EFC_Progetto_Sett_1.Models
{
    public class Trasgressore
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string Telefono { get; set; }
        public DateTime DataRegistrazione { get; set; }

        public List<Verbale> Verbali { get; set; }
    }
}
