using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dept_Web_App.Models
{
    public class Employees
    {
        [Key]
        public int EmpId { get; set; }
        public string FullName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DId { get; set; }
        public virtual Departments Department { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
