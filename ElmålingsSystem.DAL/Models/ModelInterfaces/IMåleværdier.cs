using System;

namespace ElmålingsSystem.DAL.Models
{
    public interface IMåleværdier
    {
        DateTime AflæsningDatoTid { get; set; }
        int ForbrugKWH { get; set; }
        int MåleraflæsningId { get; set; }
        double Tællerstand { get; set; }
    }
}