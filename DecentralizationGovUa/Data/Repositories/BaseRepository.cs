using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Data.Repositories
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
                    var query = $"INSERT INTO {tableName} VALUES ({valuesPlaceholder}";
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
    }
}
