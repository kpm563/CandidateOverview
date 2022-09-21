using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.BusinessDomain.DBOperations
{
    public static class SqlOperation
    {
        public static async Task<List<T>> GetDataFromSQLAsync<T>(string command, CommandType commandType, string connString = "", List<KeyValuePair<string, object>> @params = null)
        {
            if (string.IsNullOrEmpty(connString))
            {
                connString = "Server=localhost\\SQLEXPRESS;Database=DevOn;Trusted_Connection=True;";
            }

            var param = new DynamicParameters();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                if (@params != null)
                {
                    foreach (var keyValue in @params)
                    {
                        param.Add(keyValue.Key, keyValue.Value);    
                    }
                }

                return (await conn.QueryAsync<T>(command, param, commandTimeout: 150, commandType: commandType)).ToList();
            }
        }
    }
}
