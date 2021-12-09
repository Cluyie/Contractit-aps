using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ElmålingsSystem.DAL.Entities
{
    public class Måleværdier
    {
        [Key]
        public int Id { get; set; }
        public DateTime AflæsningDatoTid { get; set; }
        public double Tællerstand { get; set; }
        public int ForbrugKWH { get; set; }

        //Foreign Key
        public int MålerFK { get; set; }
        public Måler Måler { get; set; }
    }
}
