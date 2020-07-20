
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using DapperDemo.Business.Interfaces;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DapperDemo.Data.Repositories
{
   

    public class DapperRepository : IDapperRepository
    {
        private readonly IDbConnection _IDbConnection;
        public DapperRepository(IConnectionFactory Connection)
        {
            _IDbConnection = Connection.Create();
            _IDbConnection.Open();
        }

        public IDbConnection Connection { get { return _IDbConnection; } }
        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _IDbConnection.GetAll<T>();
        }

        public T GetById<T>(object Id) where T : class
        {
            return _IDbConnection.Get<T>(Id);
        }

        public long Insert<T>(T entity) where T : class
        {
            return _IDbConnection.Insert<T>(entity);
        }
        public bool Update<T>(T entity) where T : class
        {
            return _IDbConnection.Update<T>(entity);
        }
        public IEnumerable<T> Query<T>(string Query, object Param = null) where T : class
        {
            return _IDbConnection.Query<T>(Query, Param);
        }

        public void Dispose()
        {
            _IDbConnection.Close();
            _IDbConnection.Dispose();
        }
    }
}
