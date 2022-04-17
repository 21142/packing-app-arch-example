using PackingApp.Shared.Abstractions.Commands;
using System;

namespace PackingApp.Application.Commands
{
    public record AddSuitcaseItem(Guid SuitcaseId, string Name, int Quantity) : ICommand;
}
