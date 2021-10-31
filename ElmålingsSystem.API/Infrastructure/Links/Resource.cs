namespace ElmålingsSystem.API.Infrastructure
{
    public abstract class Resource : Link
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Link Self { get; set; }
    }
}
