namespace ElmålingsSystem.API.Infrastructure
{
    public class RootResponse : Resource
    {
        public Link EjerKunder { get; set; }
        public Link Installationer { get; set; }
        public Link LejerKunder { get; set; }
        public Link Måler { get; set; }
        public Link MåleVærdier { get; set; }
    }
}
