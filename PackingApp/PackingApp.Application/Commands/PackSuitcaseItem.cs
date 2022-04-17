using PackingApp.Shared.Abstractions.Commands;
using System;

namespace PackingApp.Application.Commands
{
    public record PackSuitcaseItem(Guid SuitcaseId, string Name) : ICommand;
}
