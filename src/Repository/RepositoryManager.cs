﻿// <copyright file="RepositoryManager.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Repository
{
    using Contracts;

    /// <summary>
    /// Manager class.
    /// </summary>
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext repositoryContext;
        private readonly Lazy<ICustomerRepository> customersRepository;
        private readonly Lazy<IProductRepository> productRepository;
        private readonly Lazy<IInvoiceRepository> invoiceRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryManager"/> class.
        /// </summary>
        /// <param name="repositoryContext">Context.</param>
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
            this.customersRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(this.repositoryContext));
            this.productRepository = new Lazy<IProductRepository>(() => new ProductRepository(this.repositoryContext));
            this.invoiceRepository = new Lazy<IInvoiceRepository>(() => new InvoiceRepository(this.repositoryContext));
        }

        /// <summary>
        /// Gets customerRepo.
        /// </summary>
        public ICustomerRepository CustomerRepository => this.customersRepository.Value;

        /// <summary>
        /// gets productrepo.
        /// </summary>
        public IProductRepository ProductRepository => this.productRepository.Value;

        /// <summary>
        /// gets invoice repo.
        /// </summary>
        public IInvoiceRepository InvoiceRepository => this.invoiceRepository.Value;

        /// <summary>
        /// save.
        /// </summary>
        public void Save() => this.repositoryContext.SaveChanges();
    }
}
