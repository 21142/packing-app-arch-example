using PackingApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace PackingApp.Application.DTO
{
    public class SuitcaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public IEnumerable<SuitcaseItemDto> SuitcaseItems { get; set; }
    }
}
