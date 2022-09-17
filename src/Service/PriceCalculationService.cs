// <copyright file="CalculationHelper.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Presentation.Helpers
{
    using Entities.Enums;
    using Shared.Dtos;

    /// <summary>
    /// Calculate discount class.
    /// </summary>
    public class PriceCalculationService
    {
        /// <summary>
        /// calculate method.
        /// </summary>
        /// <param name="customer">input customer for customer type.</param>
        /// <param name="products">input productss for productType and price.</param>
        /// <param name="orderList">input orderlis for product quantity</param>
        /// <returns>NetPrice.</returns>
        public CalculatedPrices PriceCalculate(CustomerDto customer, IEnumerable<ProductDto> products, IEnumerable<PaymentProcessProductDto> orderList)
        {
            var grossPrice = this.TotalGrossPrice(products, orderList);
            var grossPriceWithoutDiscountProduct = this.GrossPriceWithoutDiscountProduct(products, orderList);
            decimal discount = default(decimal);

            switch (customer.userType)
            {
                case UserType.Employee:
                    discount = grossPriceWithoutDiscountProduct * this.CalculatedDiscountPercentage(DiscountPercent.Employee);
                    break;

                case UserType.Affiliate:
                    discount = grossPriceWithoutDiscountProduct * this.CalculatedDiscountPercentage(DiscountPercent.Affiliate);
                    break;

                case UserType.Common:
                    if (DateTime.Now.Subtract(customer.creationDate).Days > 730)
                    {
                        discount = grossPriceWithoutDiscountProduct * this.CalculatedDiscountPercentage(DiscountPercent.Common);
                    }
                    else
                    {
                        discount = (int)grossPriceWithoutDiscountProduct / 100 * (decimal)DiscountPercent.Common;
                    }

                    break;
            }

            CalculatedPrices result = new()
            {
                GrossPrice = grossPrice,
                NetPrice = grossPrice - discount,
            };

            return result;
        }

        private decimal TotalGrossPrice(IEnumerable<ProductDto> products, IEnumerable<PaymentProcessProductDto> orderList)
        {
            var grossPrice = default(decimal);
            foreach (var product in products)
            {
                grossPrice += product.price * orderList.First(x => x.name.Equals(product.name, StringComparison.Ordinal)).quantity;
            }

            return grossPrice;
        }

        private decimal GrossPriceWithoutDiscountProduct(IEnumerable<ProductDto> products, IEnumerable<PaymentProcessProductDto> orderList)
        {
            var grossPriceWithoutDiscountProduct = default(decimal);
            foreach (var product in products)
            {
                grossPriceWithoutDiscountProduct = product.productType == ProductType.Groceries
                    ? grossPriceWithoutDiscountProduct
                    : grossPriceWithoutDiscountProduct + (product.price * orderList.First(x => x.name.Equals(product.name, StringComparison.Ordinal)).quantity);
            }

            return grossPriceWithoutDiscountProduct;
        }

        private decimal CalculatedDiscountPercentage(DiscountPercent discountPercent)
        {
            return (decimal)discountPercent / 100;
        }
    }
    /// <summary>
    /// dto.
    /// </summary>
    /// <param name="grossPrice">grossPrice.</param>
    /// <param name="netPrice">netPrice.</param>
    public class CalculatedPrices
    {
        /// <summary>
        /// Gets or sets grossPrice.
        /// </summary>
        public decimal GrossPrice { get; set; }

        /// <summary>
        /// Gets or sets netPrice.
        /// </summary>
        public decimal NetPrice { get; set; }
    }
}
