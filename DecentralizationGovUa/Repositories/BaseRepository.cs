using Dapper;
using DecentralizationGovUa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Repositories
{
    public class BaseRepository
    {
        protected async Task DeleteData(string tableName)
        {
            try
            {
                using (var database = Context.Connection)
                {
                    var query = $"Delete {tableName}";
                    await database.ExecuteAsync(query);
                }
            }
            catch (Exception ex)
            { 
                
            }
        }

        protected async Task InsertData<T>(string tableName, IEnumerable<T> data, string[] paramsNames)
        {
            try
            {
                using (var database = Context.Connection)
                {
                    var valuesPlaceholder = string.Join(", ", paramsNames);
                    var query = $"INSERT INTO {tableName} VALUES ({valuesPlaceholder})";
                    foreach (var item in data)
                    {
                        await database.ExecuteAsync(query, item);
                    }             
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected async Task<List<T>> SelectData<T>(string[] selectParams, string tableName, string? whereParam = default, object? data = default)
        {
            try
            {
                using (var database = Context.Connection)
                {
                    var valuesPlaceholder = string.Join(", ", selectParams);
                    var whereClause = string.IsNullOrEmpty(whereParam) ? "" : $"WHERE ({whereParam})";
                    var query = 
                        $"SELECT {valuesPlaceholder} " +
                        $"FROM {tableName} " +
                        $"{whereClause}";

                    var result = await database.QueryAsync<T>(query, data);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }

    }
}
