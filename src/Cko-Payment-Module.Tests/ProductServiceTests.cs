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
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task IfProductIsNull_ThenThrowProductNotFoundException()
        {
            var mockRepositoryManager = new Mock<IRepositoryManager>();
            mockRepositoryManager.Setup(x => x.ProductRepository.GetByIdAsync(It.IsAny<Guid>(), false)).Returns<Product>(null);
            var mockLogger = new Mock<ILoggerManager>();
            var mockMapper = new Mock<IMapper>();
            var mockServiceManager = new ServiceManager(mockRepositoryManager.Object, mockLogger.Object, mockMapper.Object);
            Guid productId = Guid.NewGuid();
            await mockServiceManager.ProductService.GetProductAsync(productId, false);
        }
    }
}
