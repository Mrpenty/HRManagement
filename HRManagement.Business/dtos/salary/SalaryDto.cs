using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Business.dtos.salary
{
    public class SalaryDto
    {
        public decimal BaseSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deduction { get; set; }
        public decimal Tax { get; set; }
        public decimal NetSalary { get; set; }
        public string SalaryPeriod { get; set; }  // Cho đẹp
    }

}
