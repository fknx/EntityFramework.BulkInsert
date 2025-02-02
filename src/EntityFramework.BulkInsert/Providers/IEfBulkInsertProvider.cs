﻿using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using EntityFramework.BulkInsert.Extensions;

namespace EntityFramework.BulkInsert.Providers
{
    public interface IEfBulkInsertProvider
    {
        /// <summary>
        /// Gets a connection from the provider.
        /// </summary>
        /// <returns></returns>
        IDbConnection GetConnection();

        /// <summary>
        /// Executes a bulk insert command from the provider.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="entities">Entities to insert.</param>
        void Run<T>(IEnumerable<T> entities);

        /// <summary>
        /// Executes a bulk insert command with a transaction from the provider.
        /// </summary>
        /// <typeparam name="T">Entity type.</typeparam>
        /// <param name="entities">Entities to insert.</param>
        /// <param name="transaction">Transaction to use for the insert.</param>
        void Run<T>(IEnumerable<T> entities, IDbTransaction transaction);

        /// <summary>
        /// Sets the database context.
        /// </summary>
        /// <param name="context">DbContext to set.</param>
        /// <returns></returns>
        IEfBulkInsertProvider SetContext(DbContext context);

        /// <summary>
        /// Sets the provider invariant name.
        /// </summary>
        /// <param name="providerInvariantName"></param>
        void SetProviderIdentifier(string providerInvariantName);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task RunAsync<T>(IEnumerable<T> entities);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task RunAsync<T>(IEnumerable<T> entities, IDbTransaction transaction);

        /// <summary>
        /// Get sql grography object from well known text
        /// </summary>
        /// <param name="wkt">Well known text representation of the value</param>
        /// <param name="srid">The identifier associated with the coordinate system.</param>
        /// <returns></returns>
        object GetSqlGeography(string wkt, int srid);

        /// <summary>
        /// Get sql geometry object from well known text
        /// </summary>
        /// <param name="wkt">Well known text representation of the value</param>
        /// <param name="srid">The identifier associated with the coordinate system.</param>
        /// <returns></returns>
        object GetSqlGeometry(string wkt, int srid);
      
        /// <summary>
        /// Current DbContext.
        /// </summary>
        DbContext Context { get; }

        /// <summary>
        /// Bulk insert options.
        /// </summary>
        BulkInsertOptions Options { get; set; }

        /// <summary>
        /// The provider identifier.
        /// </summary>
        string ProviderIdentifier { get; }
    }
}