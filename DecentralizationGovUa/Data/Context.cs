using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentralizationGovUa.Data
{
    internal static class Context
    {
        public static IDbConnection Connection 
        {
            get 
            {
                return new SqlConnection("Server=localhost\\SQLEXPRESS;Database=DecentralizationGovUa;Trusted_Connection=True;");
            }
        }
    }
}
