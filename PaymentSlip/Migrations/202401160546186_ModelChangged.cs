namespace PaymentSlip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChangged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deductions", "SalaryModel_SalaryId", "dbo.Salary");
            DropIndex("dbo.Deductions", new[] { "SalaryId" });
            DropIndex("dbo.Deductions", new[] { "SalaryModel_SalaryId" });
            DropColumn("dbo.Deductions", "SalaryId");
            RenameColumn(table: "dbo.Deductions", name: "SalaryModel_SalaryId", newName: "SalaryId");
            AlterColumn("dbo.Deductions", "SalaryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Deductions", "SalaryId");
            AddForeignKey("dbo.Deductions", "SalaryId", "dbo.Salary", "SalaryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deductions", "SalaryId", "dbo.Salary");
            DropIndex("dbo.Deductions", new[] { "SalaryId" });
            AlterColumn("dbo.Deductions", "SalaryId", c => c.Int());
            RenameColumn(table: "dbo.Deductions", name: "SalaryId", newName: "SalaryModel_SalaryId");
            AddColumn("dbo.Deductions", "SalaryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Deductions", "SalaryModel_SalaryId");
            CreateIndex("dbo.Deductions", "SalaryId");
            AddForeignKey("dbo.Deductions", "SalaryModel_SalaryId", "dbo.Salary", "SalaryId");
        }
    }
}
