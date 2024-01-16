using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSlip.Models
{
    [Table("Salary")]
    public class SalaryModel
    {             
            [Key()]
            public int SalaryId { get; set; }
            [ForeignKey("Employee")]
            [DisplayName("Employee ID")]
            public int EmpId { get; set; }
            [DisplayName("Employee Name")]
            public string EmpName { get; set; }
            [Required]
            [DisplayName("Bank")]
            public string BankName { get; set; }
            [Required]
            [DisplayName("Account Number")]
            public string Bank_accountNumber { get; set; }
            [Required]
            [DisplayName("PAN Number")]
            public string PAN_number { get; set; }
            [Required]
            [DisplayName("PF Account Number")]
            public string PF_accountNumber { get; set; }
            [Required]
            [DisplayName("Basic Salary")]
            public int BaseSalary { get; set; }

            [DisplayName("Allowances")]
            public List<AllowanceModel> Allowances { get; set; } 

            [DisplayName("Deductions")]
            public List<DeductionModel> Deductions { get; set; }
            public int NetEarning { get; set; }
            public virtual EmployeeModel Employee { get; set; }
           
    }


          [Table("Allowances")]
        public class AllowanceModel
        {
            [Key]
            public int AllowanceId { get; set; }

            [DisplayName("Type")]
            public AllowanceTypes AllowanceType { get; set; }
            [DisplayName("Amount")]

            public int AllowanceAmount { get; set; }
            [ForeignKey("Salary")]
            public int SalaryId { get; set; }

            public virtual SalaryModel Salary { get; set; }
        }

        [Table("Deductions")]
        public class DeductionModel
        {
            [Key]
            public int DeductionId { get; set; }
            [DisplayName("Type")]
            public DeductionTypes DeductionType { get; set; }
            [DisplayName("Amount")]
            public int DeductionAmount { get; set; }
            [ForeignKey("Salary")]
            public int SalaryId { get; set; }

            public virtual SalaryModel Salary { get; set; }
        }
    
}


