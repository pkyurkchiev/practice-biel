using LM.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity, string excludeProperties = "");
        void Save(T entity);
        void Delete(T entity);
        void Delete(object id);
    }
}
