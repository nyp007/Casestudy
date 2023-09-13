using System.ComponentModel.DataAnnotations;

namespace MaintainSys.Models
{
    public class Technicians
    {
        [Key]
        public int technician_Id { get; set; }

        public int User_id { get; set; }

        public string specialization { get; set; }

        public int experience_years { get; set; }

        public int rating { get; set; }
    }
}