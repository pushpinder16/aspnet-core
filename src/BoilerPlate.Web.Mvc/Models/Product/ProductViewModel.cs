using BoilerPlate.Product.Dto;
using System.Collections.Generic;

namespace BoilerPlate.Web.Models.Product
{
    public class ProductViewModel
    {
        public IReadOnlyList<ProductDto> products { get; set; }
    }
}
