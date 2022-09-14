using Entities.Enums;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = new Guid("a22ac13b-e9aa-496a-8663-6c67a15ca2d9"),
                    Name = "product1",
                    Price = 10,
                    ProductType = ProductType.Clothes,
                    Quantity = 100,
                    UpdatedTime = DateTime.Now,
                },
                new Product
                {
                    Id = new Guid("807e4cf7-c336-43a5-a7b2-941f3de8b655"),
                    Name = "product2",
                    Price = 20,
                    ProductType = ProductType.Furnitures,
                    Quantity = 50,
                    UpdatedTime = DateTime.Now,
                },
                new Product
                {
                    Id = new Guid("f715b188-178e-4108-bb62-946cddd3270d"),
                    Name = "product3",
                    Price = 30,
                    ProductType = ProductType.Cars,
                    Quantity = 10,
                    UpdatedTime = DateTime.Now,
                },
                new Product
                {
                    Id = new Guid("03b49cd7-190a-4104-82c8-4fa23f928974"),
                    Name = "product4",
                    Price = 40,
                    ProductType = ProductType.Groceries,
                    Quantity = 2500,
                    UpdatedTime = DateTime.Now,

                },
                new Product
                {
                    Id = new Guid("a6fc2c2f-6cae-4db4-8901-4fc4987d1781"),
                    Name = "product5",
                    Price = 50,
                    ProductType = ProductType.Home,
                    Quantity = 5,
                    UpdatedTime = DateTime.Now,
                }
                );
        }
    }
}
