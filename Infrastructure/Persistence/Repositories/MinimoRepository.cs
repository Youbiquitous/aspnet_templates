///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Collections.Generic;
using Expoware.Youbiquitous.Core.Extensions;
using $safeprojectname$.Infrastructure.Persistence.Model;

namespace $safeprojectname$.Infrastructure.Persistence.Repositories
{
    public abstract class MinimoRepository<TEntity> where TEntity : MinimoEntity
    {
        /// <summary>
        /// Internal (updateable) cache of entities
        /// </summary>
        private static IList<TEntity> _internalCache = new List<TEntity>();

        /// <summary>
        /// Returns the unfiltered list of ALL entity types, including inactive types (by tenant)
        /// </summary>
        /// <returns>List of TEntity objects</returns>
        public IList<TEntity> All()
        {
            var list = FindAll();
            return list;
        }

        /// <summary>
        /// Clears the internal cache
        /// </summary>
        public static void InvalidateCache()
        {
            _internalCache = null;
        }


        #region OVERRIDABLES

        /// <summary>
        /// Retrieves all entities currently in the system (by tenant)
        /// </summary>
        /// <returns>List of entities</returns>
        protected virtual IList<TEntity> FindAll()
        {
            if (_internalCache.IsNullOrEmpty())
                _internalCache = LoadFromDatabase();
            return _internalCache;
        }


        /// <summary>
        /// Retrieves records from the physical database
        /// </summary>
        /// <returns></returns>
        protected abstract IList<TEntity> LoadFromDatabase();

        #endregion
    }
}