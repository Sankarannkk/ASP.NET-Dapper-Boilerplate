using System;
using System.Data;

namespace DapperDemo.Business.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
