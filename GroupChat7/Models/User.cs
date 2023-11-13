
using System.ComponentModel.DataAnnotations;

namespace GroupChat7.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        //navitation for many-to-many relationship
        public ICollection<UserGroup> UserGroups { get; set; }
    }
}
