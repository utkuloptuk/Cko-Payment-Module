// <copyright file="IRepositoryBase.cs" company="CompanyName">
// Copyright (c) CompanyName. All rights reserved.
// </copyright>

namespace Contracts
{
    using System.Linq.Expressions;

    /// <summary>
    /// Generic CRUD interface.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Generic repository findall interface.
        /// </summary>
        /// <param name="trackChanges">trackChanges parameter use it to improve our read-only query performance.</param>
        /// <returns>Entity object.</returns>
        IQueryable<T> FindAll(bool trackChanges);

        /// <summary>
        /// Generic FindBycondition interface.
        /// </summary>
        /// <param name="expression"> By using that, we will get our values in db.</param>
        /// <param name="trackChanges">trackChanges parameter use it to improve our read-only query performance.</param>
        /// <returns>Entity object.</returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

        /// <summary>
        /// Generic create interface.
        /// </summary>
        /// <param name="entity">By using that, we will create our object.</param>
        void Create(T entity);

        /// <summary>
        /// Generic Update interface.
        /// </summary>
        /// <param name="entity">By using that, we will updated our object.</param>
        void Update(T entity);

        /// <summary>
        /// Generic delete interface.
        /// </summary>
        /// <param name="entity">By using that, we will delete our object.</param>
        void Delete(T entity);
    }
}
