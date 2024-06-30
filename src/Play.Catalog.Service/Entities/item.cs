using System;

namespace Play.Catalog.Service.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        
        public String Name { get; set; }

        public String Description { get; set; }

        public Decimal Price { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}