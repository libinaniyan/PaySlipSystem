using PaymentSlip.Models;
using System.Data.Entity;

namespace PaymentSlip.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("dbconnection")
        {
            
        }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<SalaryModel> Salary { get; set; }
        public DbSet<AllowanceModel> Allowances { get; set; }
        public DbSet<DeductionModel> Deductions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the foreign key relationship
            //modelBuilder.Entity<SalaryModel>()
            //    .HasRequired(s => s.Employee) 
            //    .WithMany()  
            //    .HasForeignKey(s => s.EmpId);


            //   modelBuilder.Entity<AllowanceModel>()
            //.HasRequired(a => a.Salary)
            //.WithMany(s => s.Allowances)
            //.HasForeignKey(a => a.SalaryId)
            //.WillCascadeOnDelete(true);

            //   // Configure foreign key for DeductionModel
            //   modelBuilder.Entity<DeductionModel>()
            //       .HasRequired(d => d.Salary)
            //       .WithMany(s => s.Deductions)
            //       .HasForeignKey(d => d.SalaryId)
            //       .WillCascadeOnDelete(true);

            //        modelBuilder.Entity<SalaryModel>()
            //.HasMany(s => s.Deductions)
            //.WithRequired(d => d.Salary)
            //.HasForeignKey(d => d.SalaryId)
            //.WillCascadeOnDelete(true);



            //modelBuilder.Entity<AllowanceModel>()
            //.HasRequired(a => a.Salary)
            //.WithMany(s => s.Allowances)
            //.HasForeignKey(a => a.SalaryId);

            //modelBuilder.Entity<DeductionModel>()
            //    .HasRequired(d => d.Salary)
            //    .WithMany()
            //    .HasForeignKey(d => d.SalaryId);

        }
    }
}
