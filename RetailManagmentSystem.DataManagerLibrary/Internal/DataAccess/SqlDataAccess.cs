using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace RetailManagmentSystem.DataManagerLibrary.Internal.DataAccess
{
    public class SqlDataAccess
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedProcedures, U parameters, string connectionStringName)
        {
            var connectionString = GetConnectionString(connectionStringName);

            using (var connection = new SqlConnection(connectionString))
            {
                var rows = connection
                                .Query<T>(storedProcedures, parameters, commandType: CommandType.StoredProcedure)
                                .ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedures, T parameters, string connectionStringName)
        {
            var connectionString = GetConnectionString(connectionStringName);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedures, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}