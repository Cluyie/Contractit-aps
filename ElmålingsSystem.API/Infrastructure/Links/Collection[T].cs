namespace ElmålingsSystem.API.Infrastructure
{
    public class Collection<T> : Resource
    {
        public T[] Value { get; set; }
    }
}
