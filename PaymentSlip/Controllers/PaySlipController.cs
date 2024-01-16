using PaymentSlip.Models;
using PaymentSlip.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PaymentSlip.Migrations;
using System.Web.Configuration;

namespace PaymentSlip.Controllers
{
    public class PaySlipController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();

        [HttpGet]
        public ActionResult GetPayslip()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetPayslip(int employeeId)
        {
            return RedirectToAction("GeneratePayslip", new { employeeId });
        }

        //[HttpGet]
        //public ActionResult GeneratePayslip()
        //{
        //    return View();
        //}
        public ActionResult GeneratePayslip(int employeeId)
        {
            EmployeeModel employee = Context.Employees.Find(employeeId);

            SalaryModel salary = Context.Salary.FirstOrDefault(s => s.EmpId == employeeId);

            if (employee == null || salary == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            var allowances = Context.Allowances.Where(s => s.SalaryId == salary.SalaryId).Select(s => s) .ToList();
            
            var deductions = Context.Deductions.Where(d => d.SalaryId == salary.SalaryId).Select(s => s) .ToList();

            PaySlipViewModel viewModel = new PaySlipViewModel
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.EmployeeName,
                Department = employee.EmployeeDepartment,
                EmployeeRole = employee.EmployeeRole,
                BankName = salary.BankName,
                AccountNumber = salary.Bank_accountNumber,
                PFNumber = salary.PF_accountNumber,
                PanCardNumber = salary.PAN_number,
                BaseSalary = salary.BaseSalary,
                Allowances = allowances,
                Deductions = deductions,
                NetEarnings = salary.NetEarning
            };
            return View(viewModel);

        }
    }
}