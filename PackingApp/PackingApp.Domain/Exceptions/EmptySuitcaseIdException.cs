using PackingApp.Shared.Abstractions.Exceptions;

namespace PackingApp.Domain.Exceptions
{
    public class EmptySuitcaseIdException : BaseException
    {
        public EmptySuitcaseIdException() : base("SuitcaseId cannot be null!")
        {
        }
    }
}
