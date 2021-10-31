namespace ElmålingsSystem.DAL.Models
{
    public interface IMåler
    {
        string MålerBeskrivelse { get; set; }
        string MålerCifre { get; set; }
        int MålerId { get; set; }
        double MåleromregningsFaktor { get; set; }
        string Målertype { get; set; }
        string Målingsenhed { get; set; }
    }
}