using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace WebApplication1.Models
{
    public class UpdateEmployeeRequest
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int id { get; set; }
        public string firstname { get; set; }
        public string? lastname { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string jobtitle { get; set; }
    }
}
