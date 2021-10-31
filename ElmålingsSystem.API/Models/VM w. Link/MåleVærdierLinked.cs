using ElmålingsSystem.API.Infrastructure;
using System;

namespace ElmålingsSystem.API.Models
{
    public class MåleVærdierLinked : Resource, IMåleVærdier
    {
        public int MåleraflæsningId { get; set; }
        public DateTime AflæsningDatoTid { get; set; }
        public double Tællerstand { get; set; }
        public int ForbrugKWH { get; set; }
    }
}
