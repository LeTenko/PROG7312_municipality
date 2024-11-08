using PROG7312_municipality.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_municipality.Repositories
{
    public class ReportRepository : RepositoryBase, IReportRepository
    {
        public void AddReport(ReportModel report)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "INSERT INTO Report (Location, Description, Category, FilePath, UserId) " +
                            "VALUES (@Location, @Description, @Category, @FilePath, @UserId)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Location", report.Location ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Description", report.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Category", report.SelectedCategory ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FilePath", report.FilePath ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@UserId", report.UserID);

                    command.ExecuteNonQuery();
                }
            }
        }




        public List<ReportModel> GetReportsByUserId(Guid userId)
        {
            var reports = new List<ReportModel>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Report WHERE UserId = @UserId";
                command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var report = new ReportModel
                        {
                            Location = reader["Location"].ToString(),
                            Description = reader["Description"].ToString(),
                            SelectedCategory = reader["Category"].ToString(),
                            FilePath = reader["FilePath"].ToString(),
                            UserID = (Guid)reader["UserId"]
                        };

                        reports.Add(report);
                    }
                }
            }

            return reports;
        }



        public ReportModel GetReportById(Guid id)
        {
            throw new NotImplementedException();
        }

       
        public IEnumerable<ReportModel> GetAllReports()
        {
            throw new NotImplementedException();
        }

    }
}
