using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElmålingsSystem.DAL.Models
{
    public class LejerKunde : IKunde
    {
        [Key]
        public int KundeId { get; set; }
        public int CprNr { get; set; }
        public string ForNavn { get; set; }
        public string EfterNavn { get; set; }
        public string VejNavn { get; set; }
        public string HusNummer { get; set; }
        public string Etage { get; set; }
        public string Dør { get; set; }
        public int PostNummer { get; set; }
        public string ByNavn { get; set; }
        public string KommuneNavn { get; set; }

        //Foreign key
        public int InstallionFK { get; set; }
        public Installation Installation { get; set; }
    }
}
