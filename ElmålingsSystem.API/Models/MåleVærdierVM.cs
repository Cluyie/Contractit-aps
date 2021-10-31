using System;

namespace ElmålingsSystem.API.Models
{
    public class MåleVærdierVM : IMåleVærdier
    {
        public DateTime AflæsningDatoTid { get; set; }
        public double Tællerstand { get; set; }
        public int ForbrugKWH { get; set; }
    }
}
