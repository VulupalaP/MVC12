using MVC12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC12.Controllers
{
    public class EmployeeController : Controller
    {
        //To test
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetEmployeesList()
        {
            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();
            List<Employee> employees = employeeDBEntities.Employees.ToList();
            return View(employees);
        }

        public ActionResult GetEmployeesById(int id)
        {
            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();
            Employee emp = employeeDBEntities.Employees.Find(id);
            return View(emp);
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee emp)
        {
            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();
            Employee employee = new Employee();
            employeeDBEntities.Employees.Add(emp);
            employeeDBEntities.SaveChanges();
            return View();
        }

        public ActionResult UpdateEmployee(Employee emp)
        {
            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();
            Employee employee = employeeDBEntities.Employees.Find(emp.Id);
            employee.EmployeeName = employee.EmployeeName;
            employee.Gender = employee.Gender;
            employee.LOcation = employee.LOcation;
            employee.Qualification = employee.Qualification;
            employeeDBEntities.SaveChanges();
            return View();
        }

        public ActionResult DeleteEmployee(int id)
        {
            EmployeeDBEntities employeeDBEntities = new EmployeeDBEntities();
            Employee emp = employeeDBEntities.Employees.Find(id);
            employeeDBEntities.Employees.Remove(emp);
            employeeDBEntities.SaveChanges();
            return View();
        }
    }
}