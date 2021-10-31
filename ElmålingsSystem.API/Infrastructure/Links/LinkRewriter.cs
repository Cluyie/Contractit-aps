using Microsoft.AspNetCore.Mvc;

namespace ElmålingsSystem.API.Infrastructure
{
    public class LinkRewriter
    {
        private readonly IUrlHelper _urlHelper;

        public LinkRewriter(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        /// <summary>
        /// method that return a new link, with a Href attribute conaining a rel Url
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public Link Rewrite(Link original)
        {
            if (original == null) return null;

            return new Link
            {
                Href = _urlHelper.Link(original.RouteName, original.RouteValues),
                Method = original.Method,
                Relations = original.Relations
            };
        }
    }
}
