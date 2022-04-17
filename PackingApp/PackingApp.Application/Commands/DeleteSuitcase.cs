using PackingApp.Shared.Abstractions.Commands;
using System;

namespace PackingApp.Application.Commands
{
    public record DeleteSuitcase(Guid SuitcaseId) : ICommand;
}
