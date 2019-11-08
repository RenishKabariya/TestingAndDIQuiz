using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_and_DI_Quiz
{
    public interface IDataAccess
    {
        double GetEmployeeSalary(int id);
        string GetTopThreeEmployees(int id);
        Employee GetEmployee(int id);
    }
    class DataAccessLayer : IDataAccess
    {
        TestingAndDIQuizDBEntities1 db = new TestingAndDIQuizDBEntities1();

        public Employee GetEmployee(int id)
        {
            return db.Employees.Find(id);
        }
        public double GetEmployeeSalary(int id)
        {
            var employee = db.Employees.Find(id);
            return employee.Salary;
        }
        public string GetTopThreeEmployees(int id)
        {
            var topThreeEmployees = db.Employees.OrderByDescending(e => e.Salary).Take(3);
            return topThreeEmployees.ToString();
        }
    }

    public class SalaryBusinessLogic
    {
        IDataAccess dta;
        public SalaryBusinessLogic(IDataAccess dta)
        {
            this.dta = dta;
        }
        public double GetEmployeeSalary(int id)
        {
            return dta.GetEmployeeSalary(id);
        }
        public double CalculateBonus(int id)
        {
            var years = Math.Truncate((DateTime.Today - dta.GetEmployee(id).Hiring_Date).TotalDays / 365);
            var salary = dta.GetEmployee(id).Salary;
            return ((years / 100) * salary);
        }
        public string GetTopThreeEmployees(int id)
        {
            return dta.GetTopThreeEmployees(id);
        }

        public void printTopSalariedEmloyees(int id)
        {
            String.Format("{0}", GetTopThreeEmployees(id));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
