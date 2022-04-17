using PackingApp.Shared.Abstractions.Exceptions;

namespace PackingApp.Domain.Exceptions
{
    public class EmptySuitcaseNameException : BaseException
    {
        public EmptySuitcaseNameException() : base("Suitcase name cannot be null!")
        {
        }
    }
}
