using System.ComponentModel.DataAnnotations;

namespace MaintainSys.Models
{
    public class Users
    {
        [Key]
        public int User_id { get; set; }

        public string Username { get; set;}

        public string Password { get; set;}

        public string Email { get; set;}

        public string Fullname { get; set;}
    }
}