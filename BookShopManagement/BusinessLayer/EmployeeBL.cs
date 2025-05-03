using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class EmployeeBL
    {
        private EmployeeDL employeeDL;

        public EmployeeBL()
        {
            employeeDL = new EmployeeDL();
        }

        public List<Employee> GetEmployees()
        {
            try
            {
                return employeeDL.GetEmployees();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool AddEmployee(Employee employee)
        {
            return employeeDL.AddEmployee(employee);
        }

        public bool UpdateEmployee(Employee employee)
        {
            return employeeDL.UpdateEmployee(employee);
        }

        public bool DeactivateEmployee(string employeeID)
        {
            return employeeDL.DeactivateEmployee(employeeID);
        }

        public List<Employee> SearchEmployees(string keyword)
        {
            try
            {
                return employeeDL.SearchEmployees(keyword);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public string GenerateNextEmployeeID()
        {
            return employeeDL.GenerateNextEmployeeID();
        }
    }
}
