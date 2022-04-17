using PackingApp.Domain.Enums;
using PackingApp.Shared.Abstractions.Commands;
using System;

namespace PackingApp.Application.Commands
{
    public record CreateSuitcaseWithItems(Guid Id, string Name, int Days, Gender Gender, LocationWriteModel Location) : ICommand;

    public record LocationWriteModel(string Country, string City);
}
