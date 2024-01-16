namespace PaymentSlip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allowances",
                c => new
                    {
                        AllowanceId = c.Int(nullable: false, identity: true),
                        AllowanceType = c.Int(nullable: false),
                        AllowanceAmount = c.Int(nullable: false),
                        SalaryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AllowanceId)
                .ForeignKey("dbo.Salary", t => t.SalaryId, cascadeDelete: true)
                .Index(t => t.SalaryId);
            
            CreateTable(
                "dbo.Salary",
                c => new
                    {
                        SalaryId = c.Int(nullable: false, identity: true),
                        EmpId = c.Int(nullable: false),
                        EmpName = c.String(),
                        BankName = c.String(nullable: false),
                        Bank_accountNumber = c.String(nullable: false),
                        PAN_number = c.String(nullable: false),
                        PF_accountNumber = c.String(nullable: false),
                        BaseSalary = c.Int(nullable: false),
                        NetEarning = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalaryId)
                .ForeignKey("dbo.EmployeeModels", t => t.EmpId, cascadeDelete: true)
                .Index(t => t.EmpId);
            
            CreateTable(
                "dbo.Deductions",
                c => new
                    {
                        DeductionId = c.Int(nullable: false, identity: true),
                        DeductionType = c.Int(nullable: false),
                        DeductionAmount = c.Int(nullable: false),
                        SalaryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeductionId)
                .ForeignKey("dbo.Salary", t => t.SalaryId, cascadeDelete: true)
                .Index(t => t.SalaryId);
            
            CreateTable(
                "dbo.EmployeeModels",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false),
                        EmployeeRole = c.Int(nullable: false),
                        EmployeeDepartment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Allowances", "SalaryId", "dbo.Salary");
            DropForeignKey("dbo.Salary", "EmpId", "dbo.EmployeeModels");
            DropForeignKey("dbo.Deductions", "SalaryId", "dbo.Salary");
            DropIndex("dbo.Deductions", new[] { "SalaryId" });
            DropIndex("dbo.Salary", new[] { "EmpId" });
            DropIndex("dbo.Allowances", new[] { "SalaryId" });
            DropTable("dbo.EmployeeModels");
            DropTable("dbo.Deductions");
            DropTable("dbo.Salary");
            DropTable("dbo.Allowances");
        }
    }
}
