// <copyright file="RepositoryBase.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Repository
{
    using System.Linq.Expressions;
    using Contracts;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Base repository class.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        /// <summary>
        /// Gets or sets repositorycontext.
        /// </summary>
        protected RepositoryContext RepositoryContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// constructor class.
        /// </summary>
        /// <param name="repositoryContext">context class.</param>
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        /// <summary>
        /// create method.
        /// </summary>
        /// <param name="entity">entity.</param>
        public void Create(T entity) => this.RepositoryContext.Set<T>().Add(entity);

        /// <summary>
        /// Delete method.
        /// </summary>
        /// <param name="entity">entity.</param>
        public void Delete(T entity) => this.RepositoryContext.Set<T>().Remove(entity);

        /// <summary>
        /// findall method.
        /// </summary>
        /// <param name="trackChanges">trackChanges parameter use it to improve our read-only query performance.</param>
        /// <returns>Entity object.</returns>
        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? this.RepositoryContext.Set<T>().AsNoTracking() : this.RepositoryContext.Set<T>();

        /// <summary>
        /// findbycondition method.
        /// </summary>
        /// <param name="expression"> By using that, we will get our values in db.</param>
        /// <param name="trackChanges">trackChanges parameter use it to improve our read-only query performance.</param>
        /// <returns>entity object.</returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? this.RepositoryContext.Set<T>().Where(expression).AsNoTracking() : this.RepositoryContext.Set<T>().Where(expression);

        /// <summary>
        /// update method.
        /// </summary>
        /// <param name="entity">input.</param>
        public void Update(T entity) => this.RepositoryContext.Set<T>().Update(entity);
    }
}
