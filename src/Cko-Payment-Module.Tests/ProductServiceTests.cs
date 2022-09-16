// <copyright file="ProductServiceTests.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Cko_Payment_Module.Tests
{
    using AutoMapper;
    using Contracts;
    using Entities.Exceptions;
    using Entities.Models;
    using Moq;
    using Service;

    /// <summary>
    /// product service test.
    /// </summary>
    [TestClass]
    public class ProductServiceTests
    {
        /// <summary>
        /// ıf product gets in db, throw error check.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ProductNotFoundException))]
        public void IfProductIsNull_ThenThrowProductNotFoundException()
        {
            var mockRepositoryManager = new Mock<IRepositoryManager>();
            mockRepositoryManager.Setup(x => x.ProductRepository.GetById(It.IsAny<Guid>(), false)).Returns<Product>(null);
            var mockLogger = new Mock<ILoggerManager>();
            var mockMapper = new Mock<IMapper>();
            var mockServiceManager = new ServiceManager(mockRepositoryManager.Object, mockLogger.Object, mockMapper.Object);
            Guid productId = Guid.NewGuid();
            mockServiceManager.ProductService.GetProduct(productId, false);
        }
    }
}
