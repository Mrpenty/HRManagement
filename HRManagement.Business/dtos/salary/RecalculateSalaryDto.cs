using System;

namespace HRManagement.Business.dtos.salary
{
    public class RecalculateSalaryDto
    {
        public int UserId { get; set; }
        public DateTime SalaryPeriod { get; set; }
    }
} 