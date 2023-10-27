using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EmpAuth
    {
        [Key]
        public string email { get; set; }
        public string password { get; set; }    
    }
}
