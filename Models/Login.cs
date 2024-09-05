using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DemoCoreMVCJune2024.Models
{
    public class Login
    {
        [Key]// Primary Key
       public int Id { get; set; }
        [Required]
       public string Username { get; set; }
        [Required]
       public string Password { get; set; }

        [Required]
        public string Role{ get; set; }   
    }
}
