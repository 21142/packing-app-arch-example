using System;
using System.Collections.Generic;

namespace PackingApp.Infrastructure.Models
{
    public class SuitcaseReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LocationReadModel Location { get; set; }
        public ICollection<SuitcaseItemReadModel> SuitcaseItems { get; set; }
    }
}
