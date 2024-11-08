using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Markup;

namespace PROG7312_municipality.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {

            // MAJOR MARK LOST HERE, ROOKIE MISTAKE
            // self constructing relative path to database.
            // locating project path , then appending the relative path to the database.

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(basePath, @"..\..\.."));
            string relativePath = @"PROG7312_municipality\MunicipalityDB.mdf";
            string fullPath = System.IO.Path.Combine(projectPath, relativePath);

            _connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={fullPath};Integrated Security=True";


        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
