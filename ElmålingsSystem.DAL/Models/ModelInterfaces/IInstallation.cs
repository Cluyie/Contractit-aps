namespace ElmålingsSystem.DAL.Models
{
    public interface IInstallation
    {
        string Afbrydelsesart { get; set; }
        string Aflæsningsform { get; set; }
        string AflæsningsFrekvens { get; set; }
        string ByNavn { get; set; }
        string Dør { get; set; }
        string EffektgrænseAmpere { get; set; }
        string EffektgrænseKW { get; set; }
        string Etage { get; set; }
        double ForventetÅrsforbrug { get; set; }
        string HusNummer { get; set; }
        int InstallationsId { get; set; }
        string LandeKode { get; set; }
        int PostNummer { get; set; }
        string Tilslutningstype { get; set; }
        string VejNavn { get; set; }
    }
}