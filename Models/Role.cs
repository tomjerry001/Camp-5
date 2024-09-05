using System.ComponentModel.DataAnnotations;
using DemoCoreMVCJune2024.Models;

namespace DemoCoreMVCJune2024.Models
{
    public class Role
    {
        [Key]// Primary Key

        public int RoleId { get; set; }

        [Required]

        public string RoleName { get; set; }
       


       
    }
}
