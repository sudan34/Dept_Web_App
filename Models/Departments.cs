using System.ComponentModel.DataAnnotations;

namespace Dept_Web_App.Models
{
    public class Departments
    {
        [Key]
        public int DId { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Employees> Employees { get; set; }
    }
}
