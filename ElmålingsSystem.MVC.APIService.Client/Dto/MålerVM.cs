namespace MyNamespace
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.27.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class MålerVM 
    {
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
    
    
    }
}