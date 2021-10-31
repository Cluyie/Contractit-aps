namespace ElmålingsSystem.API.Models
{
    public interface IMåler
    {
        string MålerBeskrivelse { get; set; }
        string MålerCifre { get; set; }
        double MåleromregningsFaktor { get; set; }
        string Målertype { get; set; }
        string Målingsenhed { get; set; }
    }
}