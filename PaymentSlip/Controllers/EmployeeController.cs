using PaymentSlip.Models;
using PaymentSlip.Data;
using System.Web.Mvc;

namespace PaymentSlip.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();
       

        [HttpGet]
        public ActionResult AddEmployees()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployees(EmployeeModel empModel)
        {
            if (ModelState.IsValid)
            {
                TempData["EmployeeName"] = empModel.EmployeeName;
                Context.Employees.Add(empModel);
                Context.SaveChanges();
                return RedirectToAction("AddSalary", "Salary");
            }
            else { return View(); }
        }
    }
}