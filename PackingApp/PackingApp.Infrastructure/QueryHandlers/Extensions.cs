using PackingApp.Application.DTO;
using PackingApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingApp.Infrastructure.QueryHandlers
{
    public static class Extensions
    {
        public static SuitcaseDto AsDto(this SuitcaseReadModel suitcaseReadModel)
            => new()
            {
                Id = suitcaseReadModel.Id,
                Name = suitcaseReadModel.Name,
                Location = new LocationDto
                {
                    Country = suitcaseReadModel.Location.Country,
                    City = suitcaseReadModel.Location.City
                },
                SuitcaseItems = suitcaseReadModel.SuitcaseItems?.Select(i => new SuitcaseItemDto
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    IsPacked = i.IsPacked
                })
            };
    }
}
