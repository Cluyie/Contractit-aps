using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ElmålingsSystem.DAL.Models
{
    public class Måler : IMåler
    {
        [Key]
        public int MålerId { get; set; }
        public double MåleromregningsFaktor { get; set; }
        public string MålerCifre { get; set; }
        public string Målertype { get; set; }
        public string Målingsenhed { get; set; }
        public string MålerBeskrivelse { get; set; }

        //Foreign key 1 til mange 
        public ICollection<Måleværdier> Måleværdier { get; set; }

        //Foreign key
        public int InstallionFK { get; set; }
        public Installation Installation { get; set; }
    }
}
