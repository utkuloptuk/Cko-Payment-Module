// <copyright file="DiscountHelperTests.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Tests
{

    using Cko_Payment_Module.Presentation.Helpers;
    using Entities.Enums;
    using Entities.Models;

    /// <summary>
    /// calculator test.
    /// </summary>
    [TestClass]
    public class DiscountHelperTests
    {
        private Customer employeeCustomer= new Customer()
        { UserType = UserType.Employee, };

        private Customer affiliateCustomer = new Customer()
        { UserType = UserType.Affiliate, };

        private Customer veteranCustomer = new Customer()
        { UserType = UserType.Common, CreationDate = DateTime.Now.AddYears(-2), };

        private Customer commonCustomer = new Customer()
        { UserType = UserType.Common, CreationDate = DateTime.Now, };

        private Invoice underto100GrossPriceWithoutGroceries = new Invoice()
        { Id = new Guid("1f3c1d6e-1148-4787-aa1c-640c5986a45f"), GrossPrice = 70, };

        private Invoice underto100GrossPriceWithGroceries = new Invoice()
        { Id = new Guid("596c91ff-0a3c-4b73-812f-9794a3beec14"), GrossPrice = 80, };

        private Invoice overto100GrossPriceWithoutGroceries = new Invoice()
        { Id = new Guid("13c7f904-6b98-4831-b08a-b9ea8c5cf8f3"), GrossPrice = 270, };

        private Invoice overto100GrossPriceWithGroceries = new Invoice()
        { Id = new Guid("8a3148ce-2d88-4056-9129-96439017869a"), GrossPrice = 260, };

        private IEnumerable<InvoiceDetail> underto100GrossPriceWithoutGroceriesInBasket = new List<InvoiceDetail>()
            {
                    new InvoiceDetail()
                {
                    Id=new Guid("1f3c1d6e-1148-4787-aa1c-640c5986a45f"),ProductId = new Guid("f715b188-178e-4108-bb62-946cddd3270d"), Quantity=1
                },
                new InvoiceDetail()
                {
                   Id=new Guid("1f3c1d6e-1148-4787-aa1c-640c5986a45f"), ProductId= new Guid("807e4cf7-c336-43a5-a7b2-941f3de8b655"), Quantity = 2,
                },
            };

        private IEnumerable<InvoiceDetail> underto100GrossPriceWithGroceriesInBasket = new List<InvoiceDetail>()
            {
                    new InvoiceDetail()
                {
                    Id = new Guid("596c91ff-0a3c-4b73-812f-9794a3beec14"),ProductId = new Guid("f715b188-178e-4108-bb62-946cddd3270d"), Quantity=1,
                },
                    new InvoiceDetail()
                {
                   Id = new Guid("596c91ff-0a3c-4b73-812f-9794a3beec14"), ProductId= new Guid("03b49cd7-190a-4104-82c8-4fa23f928974"), Quantity = 1,
                },
            };

        private IEnumerable<InvoiceDetail> overto100GrossPriceWithoutGroceriesInBasket = new List<InvoiceDetail>()
            {
                new InvoiceDetail()
        {
            Id = new Guid("13c7f904-6b98-4831-b08a-b9ea8c5cf8f3"),ProductId = new Guid("a6fc2c2f-6cae-4db4-8901-4fc4987d1781"),Quantity = 2,
                },
                new InvoiceDetail()
        {
            Id = new Guid("13c7f904-6b98-4831-b08a-b9ea8c5cf8f3"),ProductId = new Guid("f715b188-178e-4108-bb62-946cddd3270d"), Quantity = 4
                },
                new InvoiceDetail()
        {
            Id = new Guid("13c7f904-6b98-4831-b08a-b9ea8c5cf8f3"), ProductId = new Guid("a22ac13b-e9aa-496a-8663-6c67a15ca2d9"), Quantity = 5,
                },
            };

        private IEnumerable<InvoiceDetail> overto100GrossPriceWithGroceriesInBasket = new List<InvoiceDetail>()
            {
                new InvoiceDetail()
                {
                Id=new Guid("8a3148ce-2d88-4056-9129-96439017869a"),ProductId =  new Guid("a6fc2c2f-6cae-4db4-8901-4fc4987d1781"),Quantity=3,
                },
                new InvoiceDetail()
                {
                    Id=new Guid("8a3148ce-2d88-4056-9129-96439017869a"),ProductId = new Guid("03b49cd7-190a-4104-82c8-4fa23f928974"), Quantity=2
                },
                new InvoiceDetail()
                {
                   Id=new Guid("8a3148ce-2d88-4056-9129-96439017869a"), ProductId= new Guid("a22ac13b-e9aa-496a-8663-6c67a15ca2d9"), Quantity = 3,
                },
            };

        private IEnumerable<Product> mockProductList = new List<Product>()
            {
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
                },
            };


        /*
        [TestMethod]
        [DataRow(employeeCustomer, underto100GrossPriceWithoutGroceries, underto100GrossPriceWithoutGroceriesInBasket, 49)]//70
        [DataRow(employeeCustomer, underto100GrossPriceWithGroceries, underto100GrossPriceWithGroceriesInBasket, 68)]//40+40
        [DataRow(employeeCustomer, overto100GrossPriceWithoutGroceries, overto100GrossPriceWithoutGroceriesInBasket, 189)]//270
        [DataRow(employeeCustomer, overto100GrossPriceWithGroceries, overto100GrossPriceWithGroceriesInBasket, 206)]//180+80
        [DataRow(affiliateCustomer, underto100GrossPriceWithoutGroceries, underto100GrossPriceWithoutGroceriesInBasket, 63)]//70
        [DataRow(affiliateCustomer, underto100GrossPriceWithGroceries, underto100GrossPriceWithGroceriesInBasket, 76)]//40+40
        [DataRow(affiliateCustomer, overto100GrossPriceWithoutGroceries, overto100GrossPriceWithoutGroceriesInBasket, 243)]//270
        [DataRow(affiliateCustomer, overto100GrossPriceWithGroceries, overto100GrossPriceWithGroceriesInBasket, 242)]//180+80
        [DataRow(veteranCustomer, underto100GrossPriceWithoutGroceries, underto100GrossPriceWithoutGroceriesInBasket, 66.5)]//70
        [DataRow(veteranCustomer, underto100GrossPriceWithGroceries, underto100GrossPriceWithGroceriesInBasket, 72)]//40+40
        [DataRow(veteranCustomer, overto100GrossPriceWithoutGroceries, overto100GrossPriceWithoutGroceriesInBasket, 256.5)]//270
        [DataRow(veteranCustomer, overto100GrossPriceWithGroceries, overto100GrossPriceWithGroceriesInBasket, 251)]//180+80
        [DataRow(commonCustomer, underto100GrossPriceWithoutGroceries, underto100GrossPriceWithoutGroceriesInBasket, 70)]//70
        [DataRow(commonCustomer, underto100GrossPriceWithGroceries, underto100GrossPriceWithGroceriesInBasket, 80)]//40+40
        [DataRow(commonCustomer, overto100GrossPriceWithoutGroceries, overto100GrossPriceWithoutGroceriesInBasket, 260)]//270
        [DataRow(commonCustomer, overto100GrossPriceWithGroceries, overto100GrossPriceWithGroceriesInBasket, 255)]//180+80
        public void LookingForUserType_CalculateDiscount_IsTrue(Customer customer, Invoice invoice, InvoiceDetail invoiceDetail, decimal discountPrice)
        {

        }
        */

        /// <summary>
        /// EmployeeCustomerCalculateDiscountUnderTo100DollarWithoutGroceriesIsTrue.
        /// </summary>
        [TestMethod]
        public void EmployeeCustomer_CalculateDiscount_UnderTo100Dollar_WithoutGroceries_IsTrue()
        {
            decimal netPrice = 49;
            Customer cust = employeeCustomer;
            var invoice = underto100GrossPriceWithoutGroceries;
            var invoiceDetail = underto100GrossPriceWithoutGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// EmployeeCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void EmployeeCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 68;
            Customer cust = employeeCustomer;
            var invoice = underto100GrossPriceWithGroceries;
            var invoiceDetail = underto100GrossPriceWithGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// EmployeeCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void EmployeeCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = 189;
            Customer cust = employeeCustomer;
            var invoice = overto100GrossPriceWithoutGroceries;
            var invoiceDetail = overto100GrossPriceWithoutGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// EmployeeCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void EmployeeCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 206;
            Customer cust = employeeCustomer;
            var invoice = overto100GrossPriceWithGroceries;
            var invoiceDetail = overto100GrossPriceWithGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// AffiliateCustomer_CalculateDiscount_UnderTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void AffiliateCustomer_CalculateDiscount_UnderTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = 63;
            Customer cust = affiliateCustomer;
            var invoice = underto100GrossPriceWithoutGroceries;
            var invoiceDetail = underto100GrossPriceWithoutGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// AffiliateCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void AffiliateCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 76;
            Customer cust = affiliateCustomer;
            var invoice = underto100GrossPriceWithGroceries;
            var invoiceDetail = underto100GrossPriceWithGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// AffiliateCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void AffiliateCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = 243;
            Customer cust = affiliateCustomer;
            var invoice = overto100GrossPriceWithoutGroceries;
            var invoiceDetail = overto100GrossPriceWithoutGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// AffiliateCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void AffiliateCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 242;
            Customer cust = affiliateCustomer;
            var invoice = overto100GrossPriceWithGroceries;
            var invoiceDetail = overto100GrossPriceWithGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// VeteranCustomer_CalculateDiscount_UnderTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void VeteranCustomer_CalculateDiscount_UnderTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = (decimal)66.5;
            Customer cust = veteranCustomer;
            var invoice = underto100GrossPriceWithoutGroceries;
            var invoiceDetail = underto100GrossPriceWithoutGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// VeteranCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void VeteranCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 72;
            Customer cust = veteranCustomer;
            var invoice = underto100GrossPriceWithGroceries;
            var invoiceDetail = underto100GrossPriceWithGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// VeteranCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void VeteranCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = (decimal)256.5;
            Customer cust = veteranCustomer;
            var invoice = overto100GrossPriceWithoutGroceries;
            var invoiceDetail = overto100GrossPriceWithoutGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// VeteranCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void VeteranCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 251;
            Customer cust = veteranCustomer;
            var invoice = overto100GrossPriceWithGroceries;
            var invoiceDetail = overto100GrossPriceWithGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// CommonCustomer_CalculateDiscount_UnderTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void CommonCustomer_CalculateDiscount_UnderTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = 70;
            Customer cust = commonCustomer;
            var invoice = underto100GrossPriceWithoutGroceries;
            var invoiceDetail = underto100GrossPriceWithoutGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// CommonCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void CommonCustomer_CalculateDiscount_UnderTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 80;
            Customer cust = commonCustomer;
            var invoice = underto100GrossPriceWithGroceries;
            var invoiceDetail = underto100GrossPriceWithGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// CommonCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void CommonCustomer_CalculateDiscount_OverTo100Dollar_withoutGroceries_IsTrue()
        {
            decimal netPrice = 260;
            Customer cust = commonCustomer;
            var invoice = overto100GrossPriceWithoutGroceries;
            var invoiceDetail = overto100GrossPriceWithoutGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }

        /// <summary>
        /// CommonCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue.
        /// </summary>
        [TestMethod]
        public void CommonCustomer_CalculateDiscount_OverTo100Dollar_withGroceries_IsTrue()
        {
            decimal netPrice = 255;
            Customer cust = commonCustomer;
            var invoice = overto100GrossPriceWithGroceries;
            var invoiceDetail = overto100GrossPriceWithGroceriesInBasket;
            var calculatedPrice = CalculationHelper.NetPriceCalculator(cust, invoice, invoiceDetail);
            Assert.IsTrue(netPrice.Equals(calculatedPrice));
        }


    }
}
