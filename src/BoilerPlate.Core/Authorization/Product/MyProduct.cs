using Abp.Domain.Entities;
using System;

namespace BoilerPlate.Authorization.Product
{
    public class MyProduct : Entity<int>
    {

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
