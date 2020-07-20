using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Business.Interfaces
{
   public interface IDapperRepository:IDisposable  
    {
        IDbConnection Connection { get; }

        IEnumerable<T> GetAll<T>() where T : class;
        T GetById<T>(object Id) where T : class;
        long Insert<T>(T entity) where T : class;
        IEnumerable<T> Query<T>(string Query, object Param = null) where T : class;
        bool Update<T>(T entity) where T : class;
    }
}
