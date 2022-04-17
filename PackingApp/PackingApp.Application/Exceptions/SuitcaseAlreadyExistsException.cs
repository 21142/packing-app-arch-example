using PackingApp.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingApp.Application.Exceptions
{
    public class SuitcaseAlreadyExistsException : BaseException
    {
        public string Name { get; }

        public SuitcaseAlreadyExistsException(string name) : base($"Suitcase {name} already exists!")
        {
            Name = name;
        }

    }
}
