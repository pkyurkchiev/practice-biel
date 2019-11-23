using System;
using System.Collections.Generic;
using System.Text;
using TM.Data.Entities;

namespace TM.Repositories.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity, string exludeProperties = "");
        void Save(T entity);
        void Delete(object id);
        void Delete(T entity);
    }
}
