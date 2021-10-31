using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElmålingsSystem.DAL.Models
{
    public class Installation : IInstallation
    {
        [Key]
        public int InstallationsId { get; set; }
        public double ForventetÅrsforbrug { get; set; }
        public string AflæsningsFrekvens { get; set; }
        public string Aflæsningsform { get; set; }
        public string Afbrydelsesart { get; set; }
        public string Tilslutningstype { get; set; }
        public string EffektgrænseAmpere { get; set; }
        public string EffektgrænseKW { get; set; }
        public string VejNavn { get; set; }
        public string HusNummer { get; set; }
        public string Etage { get; set; }
        public string Dør { get; set; }
        public int PostNummer { get; set; }
        public string ByNavn { get; set; }
        public string LandeKode { get; set; }

        //Foreign key 1 til 1
        public Måler Måler { get; set; }

        //Foreign key 1 til 1
        public LejerKunde LejerKunde { get; set; }

        //Foreign Key til EjerKunde
        public int EjerKundeFK { get; set; }
        public EjerKunde EjerKunde { get; set; }

    }
}
