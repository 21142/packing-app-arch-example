using PackingApp.Domain.Exceptions;
using System;

namespace PackingApp.Domain.ValueObjects
{
    public record SuitcaseId
    {
        public Guid Value { get; }

        public SuitcaseId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptySuitcaseIdException();
            }

            Value = value;
        }

        public static implicit operator SuitcaseId(Guid id) => new(id);

        public static implicit operator Guid(SuitcaseId id) => id.Value;
    }
}
