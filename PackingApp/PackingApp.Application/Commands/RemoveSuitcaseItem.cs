using PackingApp.Shared.Abstractions.Commands;
using System;

namespace PackingApp.Application.Commands
{
    public record RemoveSuitcaseItem(Guid SuitcaseId, string Name) : ICommand;
}
