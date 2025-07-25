using System;

namespace HRManagement.Business.dtos.Employees
{
    public class EmployeeWithSalaryCreateDto
    {
        // Employee fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentID { get; set; }
        public int PositionID { get; set; }
        public int EmployeeLevelID { get; set; }
        public int ContractTypeID { get; set; }

        // Salary fields
        public decimal BaseSalary { get; set; }
        public decimal Allowances { get; set; }
        public DateTime SalaryPeriod { get; set; }
    }
} 