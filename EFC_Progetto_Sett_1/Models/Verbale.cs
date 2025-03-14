namespace EFC_Progetto_Sett_1.Models
{
    public class Verbale
    {
        public int Id { get; set; }
        public int TrasgressoreId { get; set; }
        public Trasgressore Trasgressore { get; set; }
        public int ViolazioneId { get; set; }
        public Violazione Violazione { get; set; }
        public DateTime DataViolazione { get; set; }
        public decimal Importo { get; set; }
        public int PuntiDecurtati { get; set; }
    }
}
