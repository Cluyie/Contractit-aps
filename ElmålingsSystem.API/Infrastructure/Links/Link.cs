namespace ElmålingsSystem.API.Infrastructure
{
    public class Link
    {
        public const string GetMethod = "GET";

        public static Link To(string routeName, object routeValues = null)
            => new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = GetMethod,
                Relations = null
            };

        public static Link ToCollection(string routeName, object routeValues = null) => new Link
        {
            RouteName = routeName,
            RouteValues = routeValues,
            Method = GetMethod,
            Relations = new[] { "collection" }
        };

        public string Href { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string[] Relations { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string Method { get; set; }

        //stores the route name and route values, before being rewritten by the LinkRewritingFilter
        [System.Text.Json.Serialization.JsonIgnore]
        public string RouteName { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public object RouteValues { get; set; }
    }
}