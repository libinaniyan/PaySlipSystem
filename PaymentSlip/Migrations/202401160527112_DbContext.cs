namespace PaymentSlip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Allowances", "SalaryModel_SalaryId", "dbo.Salary");
            DropIndex("dbo.Allowances", new[] { "SalaryId" });
            DropIndex("dbo.Allowances", new[] { "SalaryModel_SalaryId" });
            DropColumn("dbo.Allowances", "SalaryId");
            RenameColumn(table: "dbo.Allowances", name: "SalaryModel_SalaryId", newName: "SalaryId");
            AlterColumn("dbo.Allowances", "SalaryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Allowances", "SalaryId");
            AddForeignKey("dbo.Allowances", "SalaryId", "dbo.Salary", "SalaryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Allowances", "SalaryId", "dbo.Salary");
            DropIndex("dbo.Allowances", new[] { "SalaryId" });
            AlterColumn("dbo.Allowances", "SalaryId", c => c.Int());
            RenameColumn(table: "dbo.Allowances", name: "SalaryId", newName: "SalaryModel_SalaryId");
            AddColumn("dbo.Allowances", "SalaryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Allowances", "SalaryModel_SalaryId");
            CreateIndex("dbo.Allowances", "SalaryId");
            AddForeignKey("dbo.Allowances", "SalaryModel_SalaryId", "dbo.Salary", "SalaryId");
        }
    }
}
