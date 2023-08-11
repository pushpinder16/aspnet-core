﻿using Abp.AutoMapper;
using BoilerPlate.Authorization.Product;
using System;

namespace BoilerPlate.Product.Dto
{
    [AutoMapTo(typeof(MyProduct))]
    public class CreateProductDto

    {

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }


    }
}



