using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PROG7312_municipality.Repositories
{
    public class EventRepository : RepositoryBase
    {
        public List<EventItem> GetEvents()
        {
            var events = new List<EventItem>();

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT EventID, Description, EventDate, ItemType, Tag, Title, Location, CreatedBy, CreatedDate, ModifiedDate FROM Events";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        events.Add(new EventItem
                        {
                            EventID = (int)reader["EventID"],
                            Description = reader["Description"].ToString(),
                            EventDate = (DateTime)reader["EventDate"],
                            ItemType = reader["ItemType"].ToString(),
                            Tag = reader["Tag"].ToString(),
                            Title = reader["Title"].ToString(),
                            Location = reader["Location"].ToString(),
                            CreatedBy = reader["CreatedBy"].ToString(),
                            CreatedDate = (DateTime)reader["CreatedDate"],
                            ModifiedDate = (DateTime)reader["ModifiedDate"]
                        });
                    }
                }
            }

            return events;
        }
    }

    public class EventItem
    {
        public int EventID { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string ItemType { get; set; }
        public string Tag { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

       
    }
}