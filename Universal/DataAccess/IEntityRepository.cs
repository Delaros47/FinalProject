using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Universal.Entities.Abstract;

namespace Universal.DataAccess
{
    #region Comment
    //Class means it is reference type and IEntity means either we can write IEntity or anything implemented from IEntity and new() means our entity can be gotten instance from it since IEntity is an interface that's why we cannot use it cause of we can use that we want to prevent user to write IEntity in generic type
    #endregion
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
