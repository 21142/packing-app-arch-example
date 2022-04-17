using PackingApp.Application.DTO;
using PackingApp.Shared.Abstractions.Queries;
using System;

namespace PackingApp.Application.Queries
{
    public class GetSuitcase : IQuery<SuitcaseDto>
    {
        public Guid Id { get; set; }
    }
}
