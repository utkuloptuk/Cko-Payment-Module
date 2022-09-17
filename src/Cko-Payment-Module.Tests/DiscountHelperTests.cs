// <copyright file="DiscountHelperTests.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Tests
{
    using Cko_Payment_Module.Presentation.Helpers;
    using Entities.Enums;
    using Shared.Dtos;

    /// <summary>
    /// calculator test.
    /// </summary>
    [TestClass]
    public class DiscountHelperTests
    {
        /// <summary>
        /// new.
        /// </summary>
        public PriceCalculationService priceCalculationService;

        /// <summary>
        /// initialize method.
        /// </summary>
        [TestInitialize]
        public void TestInitilize()
        {
            this.priceCalculationService = new PriceCalculationService();
        }

        private CustomerDto employeeCustomer = new CustomerDto(id: Guid.NewGuid(), name: "user1", lastName: "lastname1", telNo: "111", email: "email", address: "address", userType: UserType.Employee, DateTime.Now);
        private CustomerDto affiliateCustomer = new CustomerDto(id: Guid.NewGuid(), name: "user2", lastName: "lastname2", telNo: "111", email: "email", address: "address", userType: UserType.Affiliate, DateTime.Now);
        private CustomerDto veteranCustomer = new CustomerDto(id: Guid.NewGuid(), name: "user3", lastName: "lastname3", telNo: "111", email: "email", address: "address", userType: UserType.Common, DateTime.Now.AddYears(-3));
        private CustomerDto commonCustomer = new CustomerDto(id: Guid.NewGuid(), name: "user4", lastName: "lastname4", telNo: "111", email: "email", address: "address", userType: UserType.Common, DateTime.Now);

        private IEnumerable<PaymentProcessProductDto> underto100GrossPriceWithoutGroceriesInBasket = new List<PaymentProcessProductDto>()
        {
            new PaymentProcessProductDto("product1", 2),
            new PaymentProcessProductDto("product2", 2),
        };

        private IEnumerable<PaymentProcessProductDto> underto100GrossPriceWithGroceriesInBasket = new List<PaymentProcessProductDto>()
        {
            new PaymentProcessProductDto("product1", 5),
            new PaymentProcessProductDto("product4", 1),
        };

        private IEnumerable<PaymentProcessProductDto> overto100GrossPriceWithoutGroceriesInBasket = new List<PaymentProcessProductDto>()
        {
            new PaymentProcessProductDto("product2", 3),
            new PaymentProcessProductDto("product3", 3),
        };

        private IEnumerable<PaymentProcessProductDto> overto100GrossPriceWithGroceriesInBasket = new List<PaymentProcessProductDto>()
        {
            new PaymentProcessProductDto("product3", 4),
            new PaymentProcessProductDto("product4", 3),
        };

        /*
                //private Invoice underto100GrossPriceWithoutGroceries = new Invoice()
                //{ Id = new Guid("1f3c1d6e-1148-4787-aa1c-640c5986a45f"), GrossPrice = 70, };

                //private Invoice underto100GrossPriceWithGroceries = new Invoice()
                //{ Id = new Guid("596c91ff-0a3c-4b73-812f-9794a3beec14"), GrossPrice = 80, };

                //private Invoice overto100GrossPriceWithoutGroceries = new Invoice()
                //{ Id = new Guid("13c7f904-6b98-4831-b08a-b9ea8c5cf8f3"), GrossPrice = 270, };

                //private Invoice overto100GrossPriceWithGroceries = new Invoice()
                //{ Id = new Guid("8a3148ce-2d88-4056-9129-96439017869a"), GrossPrice = 260, };

                //private IEnumerable<InvoiceDetail> underto100GrossPriceWithoutGroceriesInBasket = new List<InvoiceDetail>()
                //    {
                //            new InvoiceDetail()
                //        {
                //            Id=new Guid("1f3c1d6e-1148-4787-aa1c-640c5986a45f"),ProductId = new Guid("f715b188-178e-4108-bb62-946cddd3270d"), Quantity=1
                //        },
                //        new InvoiceDetail()
                //        {
                //           Id=new Guid("1f3c1d6e-1148-4787-aa1c-640c5986a45f"), ProductId= new Guid("807e4cf7-c336-43a5-a7b2-941f3de8b655"), Quantity = 2,
                //        },
                //    };

                //private IEnumerable<InvoiceDetail> underto100GrossPriceWithGroceriesInBasket = new List<InvoiceDetail>()
                //    {
                //            new InvoiceDetail()
                //        {
                //            Id = new Guid("596c91ff-0a3c-4b73-812f-9794a3beec14"),ProductId = new Guid("f715b188-178e-4108-bb62-946cddd3270d"), Quantity=1,
                //        },
                //            new InvoiceDetail()
                //        {
                //           Id = new Guid("596c91ff-0a3c-4b73-812f-9794a3beec14"), ProductId= new Guid("03b49cd7-190a-4104-82c8-4fa23f928974"), Quantity = 1,
                //        },
                //    };

                //private IEnumerable<InvoiceDetail> overto100GrossPriceWithoutGroceriesInBasket = new List<InvoiceDetail>()
                //    {
                //        new InvoiceDetail()
                //{
                //    Id = new Guid("13c7f904-6b98-4831-b08a-b9ea8c5cf8f3"),ProductId = new Guid("a6fc2c2f-6cae-4db4-8901-4fc4987d1781"),Quantity = 2,
                //        },
                //        new InvoiceDetail()
                //{
                //    Id = new Guid("13c7f904-6b98-4831-b08a-b9ea8c5cf8f3"),ProductId = new Guid("f715b188-178e-4108-bb62-946cddd3270d"), Quantity = 4
                //        },
                //        new InvoiceDetail()
                //{
                //    Id = new Guid("13c7f904-6b98-4831-b08a-b9ea8c5cf8f3"), ProductId = new Guid("a22ac13b-e9aa-496a-8663-6c67a15ca2d9"), Quantity = 5,
                //        },
                //    };

                //private IEnumerable<InvoiceDetail> overto100GrossPriceWithGroceriesInBasket = new List<InvoiceDetail>()
                //    {
                //        new InvoiceDetail()
                //        {
                //        Id=new Guid("8a3148ce-2d88-4056-9129-96439017869a"),ProductId =  new Guid("a6fc2c2f-6cae-4db4-8901-4fc4987d1781"),Quantity=3,
                //        },
                //        new InvoiceDetail()
                //        {
                //            Id=new Guid("8a3148ce-2d88-4056-9129-96439017869a"),ProductId = new Guid("03b49cd7-190a-4104-82c8-4fa23f928974"), Quantity=2
                //        },
                //        new InvoiceDetail()
                //        {
                //           Id=new Guid("8a3148ce-2d88-4056-9129-96439017869a"), ProductId= new Guid("a22ac13b-e9aa-496a-8663-6c67a15ca2d9"), Quantity = 3,
                //        },
                //    };
        */
        private IEnumerable<ProductDto> mockProductList = new List<ProductDto>()
            {
            new ProductDto(new Guid("a22ac13b-e9aa-496a-8663-6c67a15ca2d9"), "product1", 10, ProductType.Clothes),
            new ProductDto(new Guid("807e4cf7-c336-43a5-a7b2-941f3de8b655"), "product2", 20, ProductType.Furnitures),
            new ProductDto(new Guid("f715b188-178e-4108-bb62-946cddd3270d"), "product3", 30, ProductType.Cars),
            new ProductDto(new Guid("03b49cd7-190a-4104-82c8-4fa23f928974"), "product4", 40, ProductType.Groceries),
            new ProductDto(new Guid("a6fc2c2f-6cae-4db4-8901-4fc4987d1781"), "product5", 50, ProductType.Home),
            };

        /// <summary>
        /// EmployeeCustomerCalculateDiscountUnderTo100DollarWithoutGroceriesIsTrue.
        /// </summary>
        [TestMethod]
        public void EmployeeCustomer_CalculateDiscount_UnderTo100Dollar_WithoutGroceries_IsTrue()
        {
            decimal netPrice = 42;
            decimal grossPrice = 60;
            var products = this.mockProductList.Where(x => this.underto100GrossPriceWithoutGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.employeeCustomer, products, this.underto100GrossPriceWithoutGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// EmployeeCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void EmployeeCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 75;
            decimal grossPrice = 90;
            var products = this.mockProductList.Where(x => this.underto100GrossPriceWithGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.employeeCustomer, products, this.underto100GrossPriceWithGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// EmployeeCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void EmployeeCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = 105;
            decimal grossPrice = 150;
            var products = this.mockProductList.Where(x => this.overto100GrossPriceWithoutGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.employeeCustomer, products, this.overto100GrossPriceWithoutGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// EmployeeCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void EmployeeCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 204;
            decimal grossPrice = 240;
            var products = this.mockProductList.Where(x => this.overto100GrossPriceWithGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.employeeCustomer, products, this.overto100GrossPriceWithGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// AffiliateCustomer_CalculateDiscount_UnderTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void AffiliateCustomer_CalculateDiscount_UnderTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = 54;
            decimal grossPrice = 60;
            var products = this.mockProductList.Where(x => this.underto100GrossPriceWithoutGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.affiliateCustomer, products, this.underto100GrossPriceWithoutGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// AffiliateCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void AffiliateCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 85;
            decimal grossPrice = 90;
            var products = this.mockProductList.Where(x => this.underto100GrossPriceWithGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.affiliateCustomer, products, this.underto100GrossPriceWithGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// AffiliateCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void AffiliateCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = 135;
            decimal grossPrice = 150;
            var products = this.mockProductList.Where(x => this.overto100GrossPriceWithoutGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.affiliateCustomer, products, this.overto100GrossPriceWithoutGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// AffiliateCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void AffiliateCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 228;
            decimal grossPrice = 240;
            var products = this.mockProductList.Where(x => this.overto100GrossPriceWithGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.affiliateCustomer, products, this.overto100GrossPriceWithGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// VeteranCustomer_CalculateDiscount_UnderTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void VeteranCustomer_CalculateDiscount_UnderTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = 57;
            decimal grossPrice = 60;
            var products = this.mockProductList.Where(x => this.underto100GrossPriceWithoutGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.veteranCustomer, products, this.underto100GrossPriceWithoutGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// VeteranCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void VeteranCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 87.50M;
            decimal grossPrice = 90;
            var products = this.mockProductList.Where(x => this.underto100GrossPriceWithGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.veteranCustomer, products, this.underto100GrossPriceWithGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// VeteranCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void VeteranCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = 142.5M;
            decimal grossPrice = 150;
            var products = this.mockProductList.Where(x => this.overto100GrossPriceWithoutGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.veteranCustomer, products, this.overto100GrossPriceWithoutGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// VeteranCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void VeteranCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 234;
            decimal grossPrice = 240;
            var products = this.mockProductList.Where(x => this.overto100GrossPriceWithGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.veteranCustomer, products, this.overto100GrossPriceWithGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// CommonCustomer_CalculateDiscount_UnderTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void CommonCustomer_CalculateDiscount_UnderTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = 60;
            decimal grossPrice = 60;
            var products = this.mockProductList.Where(x => this.underto100GrossPriceWithoutGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.commonCustomer, products, this.underto100GrossPriceWithoutGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// CommonCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void CommonCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 90;
            decimal grossPrice = 90;
            var products = this.mockProductList.Where(x => this.underto100GrossPriceWithGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.commonCustomer, products, this.underto100GrossPriceWithGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// CommonCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void CommonCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = 145;
            decimal grossPrice = 150;
            var products = this.mockProductList.Where(x => this.overto100GrossPriceWithoutGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.commonCustomer, products, this.overto100GrossPriceWithoutGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }

        /// <summary>
        /// CommonCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void CommonCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 235;
            decimal grossPrice = 240;
            var products = this.mockProductList.Where(x => this.overto100GrossPriceWithGroceriesInBasket.Select(x => x.name).Contains(x.name));
            var calculatedPrice = this.priceCalculationService.PriceCalculate(this.commonCustomer, products, this.overto100GrossPriceWithGroceriesInBasket);
            Assert.IsTrue(netPrice.Equals(calculatedPrice.NetPrice));
            Assert.IsTrue(grossPrice.Equals(calculatedPrice.GrossPrice));
        }
    }
}
