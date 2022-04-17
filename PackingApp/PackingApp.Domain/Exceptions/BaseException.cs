using System;

namespace PackingApp.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected BaseException(string message) : base(message)
        {
        }
    }
}
