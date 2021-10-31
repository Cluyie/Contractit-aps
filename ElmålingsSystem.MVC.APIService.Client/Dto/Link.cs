namespace MyNamespace
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Link 
    {
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