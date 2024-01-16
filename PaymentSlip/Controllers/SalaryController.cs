using log4net;
using Newtonsoft.Json;
using PaymentSlip.Models;
using PaymentSlip.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PaymentSlip.Controllers
{
    public class SalaryController : Controller
    {

         ApplicationDbContext Context = new ApplicationDbContext();
       
        [HttpGet]
        public ActionResult AddSalary()
        {
            string employeeName = (string)TempData["EmployeeName"];
            SalaryModel model = new SalaryModel();
            model.EmpId = Context.Employees.Where(e => e.EmployeeName == employeeName).Select(b => b.EmployeeId).FirstOrDefault();
            model.EmpName = employeeName;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSalary(SalaryModel salaryModel, string combinedDataJson)

        {
            try
            {
                string[] arr = combinedDataJson.Split('+');
                var deductionString = arr[0];
                var allowanceString = arr[1];
                int plusIndex = combinedDataJson.IndexOf('+');

                string deductionsString = combinedDataJson.Substring(1, plusIndex - 1).Trim().Replace(@"\", string.Empty);
                string allowancesString = combinedDataJson.Substring(plusIndex + 1, allowanceString.Length - 1).Trim().Replace(@"\", string.Empty);

                List<AllowanceModel> allowances = JsonConvert.DeserializeObject<List<AllowanceModel>>(allowancesString);
                List<DeductionModel> deductions = JsonConvert.DeserializeObject<List<DeductionModel>>(deductionsString);

                int totalAllowances = allowances.Sum(allowance => allowance.AllowanceAmount);
                int totalDeductions = deductions.Sum(deduction => deduction.DeductionAmount);

                salaryModel.NetEarning = salaryModel.BaseSalary + totalAllowances - totalDeductions;


                if (ModelState.IsValid)
                {
                    Context.Salary.Add(salaryModel);
                    Context.SaveChanges();
                    foreach (var deduction in deductions)
                    {
                        deduction.SalaryId = salaryModel.SalaryId;
                        Context.Deductions.Add(deduction);
                    }
                    Context.SaveChanges();
                    foreach (var allowance in allowances)
                    {
                        allowance.SalaryId = salaryModel.SalaryId;
                        Context.Allowances.Add(allowance);
                    }
                    Context.SaveChanges();
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
                else
                {
                    ILog log = log4net.LogManager.GetLogger(typeof(SalaryController));
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var error in modelState.Errors)
                        {
                            log.Error($"ModelState error: {error.ErrorMessage}");
                        }
                    }
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception exception)
            {
                ILog log = log4net.LogManager.GetLogger(typeof(SalaryController));
                log.Error($"Exception: {exception.Message}");
            }
            return View();
        }
    }
}