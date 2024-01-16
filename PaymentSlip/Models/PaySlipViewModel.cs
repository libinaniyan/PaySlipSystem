using System.Collections.Generic;
using System.ComponentModel;

namespace PaymentSlip.Models
{
    public class PaySlipViewModel
    {
        [DisplayName("Employee Code")]
        public int EmployeeId { get; set; }
        [DisplayName("Employee Name")]
        public string Name { get; set; }
        [DisplayName("Employee Department")]
        public Department Department { get; set; }
        [DisplayName("Employee Role")]
        public Role EmployeeRole { get; set; }
        [DisplayName("Bank Name")]
        public string BankName { get; set; }
        [DisplayName("Bank Account Number")]
        public string AccountNumber { get; set; }
        [DisplayName("PF Account Number")]
        public string PFNumber { get; set; }
        [DisplayName("PAN Card Number")]
        public string PanCardNumber { get; set; }
        [DisplayName("Basic Salary")]
        public int BaseSalary { get; set; }
        [DisplayName("Allowances")]
        public List<AllowanceModel> Allowances { get; set; }
        [DisplayName("Deductions")]       
        public List<DeductionModel> Deductions { get; set; }
        [DisplayName("Net Pay")]
        public int NetEarnings { get; set; }
    }
    public enum AllowanceTypes
    {
        HRA,
        Bonus,
        Overtime
    }
    public enum DeductionTypes
    {       
        PF,Tax
    }
    
}


