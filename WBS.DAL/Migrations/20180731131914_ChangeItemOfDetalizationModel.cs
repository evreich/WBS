using Microsoft.EntityFrameworkCore.Migrations;

namespace WBS.DAL.Migrations
{
    public partial class ChangeItemOfDetalizationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemOfInvestment",
                table: "ItemOfBudgetPlans",
                newName: "SubjectOfInvestment");

            migrationBuilder.RenameColumn(
                name: "InvestmentDate",
                table: "ItemOfBudgetPlans",
                newName: "DateOfDelivery");

            migrationBuilder.RenameColumn(
                name: "CostItem",
                table: "ItemOfBudgetPlans",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "AmountAllItems",
                table: "ItemOfBudgetPlans",
                newName: "Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectOfInvestment",
                table: "ItemOfBudgetPlans",
                newName: "ItemOfInvestment");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ItemOfBudgetPlans",
                newName: "CostItem");

            migrationBuilder.RenameColumn(
                name: "DateOfDelivery",
                table: "ItemOfBudgetPlans",
                newName: "InvestmentDate");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ItemOfBudgetPlans",
                newName: "AmountAllItems");
        }
    }
}
