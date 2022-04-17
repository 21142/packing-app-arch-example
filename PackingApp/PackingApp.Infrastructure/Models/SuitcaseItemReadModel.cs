using System;

namespace PackingApp.Infrastructure.Models
{
    public class SuitcaseItemReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsPacked { get; set; } 
        public SuitcaseReadModel Suitcase { get; set; }
    }
}
