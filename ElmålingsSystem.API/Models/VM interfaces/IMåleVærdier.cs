using System;

namespace ElmålingsSystem.API.Models
{
    public interface IMåleVærdier
    {
        DateTime AflæsningDatoTid { get; set; }
        int ForbrugKWH { get; set; }
        double Tællerstand { get; set; }
    }
}