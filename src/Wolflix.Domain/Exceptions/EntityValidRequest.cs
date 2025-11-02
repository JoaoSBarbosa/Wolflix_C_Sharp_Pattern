namespace Wolflix.Domain.Exceptions
{
    public class EntityValidRequest : Exception
    {
        public EntityValidRequest(string? message) : base(message)
        {
        }
    }
}
