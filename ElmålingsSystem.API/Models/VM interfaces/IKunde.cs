namespace ElmålingsSystem.API.Models
{
    public interface IKunde
    {
        int CPRNr { get; set; }
        string ByNavn { get; set; }
        string Dør { get; set; }
        string EfterNavn { get; set; }
        string Etage { get; set; }
        string ForNavn { get; set; }
        string HusNummer { get; set; }
        string KommuneNavn { get; set; }
        int PostNummer { get; set; }
        string VejNavn { get; set; }
    }
}

