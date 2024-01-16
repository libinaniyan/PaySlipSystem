using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaymentSlip.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }
        [Required]
        [DisplayName("Employee Role")]
        public Role EmployeeRole { get; set; }
        [Required]
        [DisplayName("Employee Department")]
        public Department EmployeeDepartment { get; set; }
    }
    public enum Role
    {
        Manager = 0, Developer = 1, QA = 2, HR = 3, Accountant = 4
    }

    public enum Department
    {
        Accounts = 0, Engineering = 1, HR = 2
    }
}