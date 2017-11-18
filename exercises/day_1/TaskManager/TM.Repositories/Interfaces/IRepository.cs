using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TM.Data.Entities;

namespace TM.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll(bool? isActive = null);

        T GetById(object id, bool? isActive = null);

        void Insert(T entity);

        void Update(T entity, string excludeProperties = "");

        void Save(T entity);

        void ActivateDeactivate(T entity);

        void ActivateDeactivate(object id);

        void Delete(object id);

        void Delete(T entity);

        void Detach(T entity);

        IEnumerable<T> Find(Expression<Func<T, bool>> where,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderByDescending = null, string includeProperties = "", bool? isActive = null);
    }
}
