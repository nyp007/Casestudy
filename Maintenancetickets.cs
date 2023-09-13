using System.ComponentModel.DataAnnotations;

namespace MaintainSys.Models
{
    public class Maintenancetickets
    {
        [Key]
        public int ticket_id { get; set; }

        public int requested_by_user_id { get; set; }

        public int assigned_to_user_id { get; set; }

        public string request_description { get; set; }

        public string status { get; set; }

        public DateTime created_at { get; set; }

    }
}