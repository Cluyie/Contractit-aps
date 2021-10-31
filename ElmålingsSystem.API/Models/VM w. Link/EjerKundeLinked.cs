using ElmålingsSystem.API.Infrastructure;

namespace ElmålingsSystem.API.Models
{
    public class EjerKundeLinked : Resource, IKunde
    {
        public int KundeId { get; set; }
        public int CPRNr { get; set; }
        public string ForNavn { get; set; }
        public string EfterNavn { get; set; }
        public string VejNavn { get; set; }
        public string HusNummer { get; set; }
        public string Etage { get; set; }
        public string Dør { get; set; }
        public int PostNummer { get; set; }
        public string ByNavn { get; set; }
        public string KommuneNavn { get; set; }
    }
}
