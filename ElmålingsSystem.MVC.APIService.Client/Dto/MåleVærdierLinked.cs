namespace MyNamespace
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class MåleVærdierLinked 
    {
        [Newtonsoft.Json.JsonProperty("måleraflæsningId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MåleraflæsningId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("aflæsningDatoTid", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset AflæsningDatoTid { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tællerstand", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Tællerstand { get; set; }
    
        [Newtonsoft.Json.JsonProperty("forbrugKWH", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ForbrugKWH { get; set; }
    
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