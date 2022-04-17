using PackingApp.Domain.ValueObjects;
using PackingApp.Shared.Abstractions.Exceptions;

namespace PackingApp.Application.Exceptions
{
    public class SuitcaseNotFoundException : BaseException
    {
        public SuitcaseNotFoundException(SuitcaseId id) : base($"Suitcase with id: {id} couldn't be found!")
        {
        }
    }
}
