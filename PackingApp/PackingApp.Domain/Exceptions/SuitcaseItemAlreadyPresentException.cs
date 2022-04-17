namespace PackingApp.Domain.Exceptions
{
    public class SuitcaseItemAlreadyPresentException : BaseException
    {
        public SuitcaseItemAlreadyPresentException(string suitcaseName, string suitcaseItem) : base($"{suitcaseItem} is already present in suitcase {suitcaseName}!")
        {
        }
    }
}
