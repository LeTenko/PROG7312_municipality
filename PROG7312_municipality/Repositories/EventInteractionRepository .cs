using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PROG7312_municipality.Model;

namespace PROG7312_municipality.Repositories
{
    public class EventInteractionRepository : RepositoryBase
    {
        public async Task SaveEventClickAsync(int eventId, Guid userId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "INSERT INTO EventClicks (EventID, UserID, ClickTime) VALUES (@EventID, @UserID, @ClickTime)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EventID", eventId);
                command.Parameters.AddWithValue("@UserID", userId); 
                command.Parameters.AddWithValue("@ClickTime", DateTime.Now);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }
        public void SaveEventLike(int eventId, Guid userId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "INSERT INTO EventLikes (EventID, UserID, LikeTime) VALUES (@EventID, @UserID, @LikeTime)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EventID", eventId);
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@LikeTime", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public async Task<List<EventClickModel>> GetClickedEventsAsync()
        {
            var clicks = new List<EventClickModel>();

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT ClickID, EventID, UserID, ClickTime FROM EventClicks";
                SqlCommand command = new SqlCommand(query, connection);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        clicks.Add(new EventClickModel
                        {
                            ClickID = (int)reader["ClickID"],
                            EventID = (int)reader["EventID"],
                            UserID = reader.GetGuid(reader.GetOrdinal("UserID")),
                            ClickTime = (DateTime)reader["ClickTime"]
                        });
                    }
                }
            }

            return clicks;
        }

        public List<EventLikeModel> GetEventLikes()
        {
            var likes = new List<EventLikeModel>();

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT LikeID, EventID, UserID, LikeTime FROM EventLikes";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        likes.Add(new EventLikeModel
                        {
                            LikeID = (int)reader["LikeID"],
                            EventID = (int)reader["EventID"],
                            UserID = reader.GetGuid(reader.GetOrdinal("UserID")), 
                            LikeTime = (DateTime)reader["LikeTime"]
                        });
                    }
                }
            }

            return likes;
        }
    }
}