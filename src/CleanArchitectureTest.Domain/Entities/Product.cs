using CleanArchitectureTest.Domain.Common;

namespace CleanArchitectureTest.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int Id { get; set; }
        public string SKU { get; set; }
    }
}