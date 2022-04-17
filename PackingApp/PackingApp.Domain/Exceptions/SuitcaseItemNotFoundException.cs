using PackingApp.Shared.Abstractions.Exceptions;

namespace PackingApp.Domain.Exceptions
{
    public class SuitcaseItemNotFoundException : BaseException
    {
        public string SuitcaseItemName { get; }
        
        public SuitcaseItemNotFoundException(string suitcaseItemName) : base($"Suitcase item {suitcaseItemName} was not found!")
        {
            SuitcaseItemName = suitcaseItemName;
        }

    }
}
