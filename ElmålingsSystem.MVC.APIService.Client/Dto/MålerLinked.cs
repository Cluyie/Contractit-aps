namespace MyNamespace
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class MålerLinked 
    {
        [Newtonsoft.Json.JsonProperty("målerId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MålerId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("måleromregningsFaktor", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double MåleromregningsFaktor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("målerCifre", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MålerCifre { get; set; }
    
        [Newtonsoft.Json.JsonProperty("målertype", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Målertype { get; set; }
    
        [Newtonsoft.Json.JsonProperty("målingsenhed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Målingsenhed { get; set; }
    
        [Newtonsoft.Json.JsonProperty("målerBeskrivelse", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MålerBeskrivelse { get; set; }
    
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