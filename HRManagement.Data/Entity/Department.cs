using System.ComponentModel.DataAnnotations;

namespace HRManagement.Data.Entity
{
    public class Department
    {
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<Employee> Employees { get; set; }
    }
}
