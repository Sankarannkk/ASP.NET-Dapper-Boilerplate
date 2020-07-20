using Dapper;
using DapperDemo.Business;
using DapperDemo.Business.Interfaces;
using DapperDemo.Business.Models;
using DapperDemo.Data.Repositories;
using System.Linq;

namespace DapperDemo.Data
{
    public static class UserRoleProvider
    {
        public static string[] GetRolesForuser(string UserName)
        {
            using (IDapperRepository Repository = new DapperRepository(new ConnectionFactory()))
            {
                var Query = "SELECT * FROM UserMaster AS U INNER JOIN UserRole AS R ON U.roleId==R.roleId WHERE (userName=@username)";
                var Roles = Repository.Connection.Query<UserRole>(Query, new { username = UserName }).FirstOrDefault();
                if (Roles != null)
                    return Roles.RoleName.Split(',');
                return "unauthorized".Split(',');
            }
        }
        public static bool IsInRole(string UserName, string RoleName)
        {
            using (IDapperRepository Repository = new DapperRepository(new ConnectionFactory()))
            {
                var Query = "SELECT COUNT(*) FROM UserMaster AS U INNER JOIN UserRole AS R ON U.roleId==R.roleId WHERE R.roleName=@rolename AND U.userName=@username ";
                var IsExists = Repository.Connection.ExecuteScalar<int>(Query, new { username = UserName, rolename= RoleName });
                if (IsExists == 0)
                    return false;
                return true;
            }
        }
    }
}
