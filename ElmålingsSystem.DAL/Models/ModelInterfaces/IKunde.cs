namespace ElmålingsSystem.DAL.Models
{
    public interface IKunde
    {
        string ByNavn { get; set; }
        string Dør { get; set; }
        string EfterNavn { get; set; }
        string Etage { get; set; }
        string ForNavn { get; set; }
        string HusNummer { get; set; }
        string KommuneNavn { get; set; }
        int KundeId { get; set; }
        int PostNummer { get; set; }
        string VejNavn { get; set; }
        int CprNr { get; set; }

    }
}