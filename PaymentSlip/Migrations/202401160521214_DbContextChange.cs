namespace PaymentSlip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbContextChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Allowances", "SalaryId", "dbo.Salary");
            DropForeignKey("dbo.Deductions", "SalaryId", "dbo.Salary");
            AddColumn("dbo.Allowances", "SalaryModel_SalaryId", c => c.Int());
            AddColumn("dbo.Deductions", "SalaryModel_SalaryId", c => c.Int());
            CreateIndex("dbo.Allowances", "SalaryModel_SalaryId");
            CreateIndex("dbo.Deductions", "SalaryModel_SalaryId");
            AddForeignKey("dbo.Allowances", "SalaryModel_SalaryId", "dbo.Salary", "SalaryId", cascadeDelete: true);
            AddForeignKey("dbo.Deductions", "SalaryModel_SalaryId", "dbo.Salary", "SalaryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deductions", "SalaryModel_SalaryId", "dbo.Salary");
            DropForeignKey("dbo.Allowances", "SalaryModel_SalaryId", "dbo.Salary");
            DropIndex("dbo.Deductions", new[] { "SalaryModel_SalaryId" });
            DropIndex("dbo.Allowances", new[] { "SalaryModel_SalaryId" });
            DropColumn("dbo.Deductions", "SalaryModel_SalaryId");
            DropColumn("dbo.Allowances", "SalaryModel_SalaryId");
            AddForeignKey("dbo.Deductions", "SalaryId", "dbo.Salary", "SalaryId", cascadeDelete: true);
            AddForeignKey("dbo.Allowances", "SalaryId", "dbo.Salary", "SalaryId", cascadeDelete: true);
        }
    }
}
