namespace MyNamespace
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class InstallationLinked 
    {
        

        [Newtonsoft.Json.JsonProperty("installationsId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int InstallationsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("forventetÅrsforbrug", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ForventetÅrsforbrug { get; set; }
    
        [Newtonsoft.Json.JsonProperty("aflæsningsFrekvens", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AflæsningsFrekvens { get; set; }
    
        [Newtonsoft.Json.JsonProperty("aflæsningsform", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Aflæsningsform { get; set; }
    
        [Newtonsoft.Json.JsonProperty("afbrydelsesart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Afbrydelsesart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tilslutningstype", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Tilslutningstype { get; set; }
    
        [Newtonsoft.Json.JsonProperty("effektgrænseAmpere", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EffektgrænseAmpere { get; set; }
    
        [Newtonsoft.Json.JsonProperty("effektgrænseKW", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EffektgrænseKW { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vejNavn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VejNavn { get; set; }
    
        [Newtonsoft.Json.JsonProperty("husNummer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HusNummer { get; set; }
    
        [Newtonsoft.Json.JsonProperty("etage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Etage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dør", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Dør { get; set; }
    
        [Newtonsoft.Json.JsonProperty("postNummer", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PostNummer { get; set; }
    
        [Newtonsoft.Json.JsonProperty("byNavn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ByNavn { get; set; }
    
        [Newtonsoft.Json.JsonProperty("landeKode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LandeKode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("self", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Link Self { get; set; }
    
        [Newtonsoft.Json.JsonProperty("href", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Href { get; set; }
    
        [Newtonsoft.Json.JsonProperty("relations", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Relations { get; set; }
    
        [Newtonsoft.Json.JsonProperty("method", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Method { get; set; }
    
        [Newtonsoft.Json.JsonProperty("routeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RouteName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("routeValues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public object RouteValues { get; set; }
    
    
    }
}