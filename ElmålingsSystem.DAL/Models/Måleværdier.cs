using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ElmålingsSystem.DAL.Models
{
    public class Måleværdier : IMåleværdier
    {
        [Key]
        public int MåleraflæsningId { get; set; }
        public DateTime AflæsningDatoTid { get; set; }
        public double Tællerstand { get; set; }
        public int ForbrugKWH { get; set; }

        //Foreign Key
        public int MålerFK { get; set; }
        public Måler Måler { get; set; }
    }
}
