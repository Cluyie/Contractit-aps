namespace MyNamespace
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class EjerKundeLinked 
    {
        [Newtonsoft.Json.JsonProperty("kundeId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int KundeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("cprNr", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CprNr { get; set; }
    
        [Newtonsoft.Json.JsonProperty("forNavn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ForNavn { get; set; }
    
        [Newtonsoft.Json.JsonProperty("efterNavn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EfterNavn { get; set; }
    
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
    
        [Newtonsoft.Json.JsonProperty("kommuneNavn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string KommuneNavn { get; set; }
    
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