using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBConnection.Migrations
{
    /// <inheritdoc />
    public partial class _20261118Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyExpense_Mortgage_MortgageId",
                table: "PropertyExpense");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyModel",
                table: "PropertyModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyExpense",
                table: "PropertyExpense");

            migrationBuilder.RenameTable(
                name: "PropertyModel",
                newName: "PropertyModels");

            migrationBuilder.RenameTable(
                name: "PropertyExpense",
                newName: "PropertyExpenses");

            migrationBuilder.RenameColumn(
                name: "InterestRate",
                table: "Mortgage",
                newName: "AnnualPromotionalInterestRate");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyExpense_MortgageId",
                table: "PropertyExpenses",
                newName: "IX_PropertyExpenses_MortgageId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Mortgage",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PropertyModelId",
                table: "Mortgage",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Owned",
                table: "PropertyModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "PropertyExpenses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PropertyExpenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyModels",
                table: "PropertyModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyExpenses",
                table: "PropertyExpenses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CompanyExpenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyExpenseType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyExpenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyIncome",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IncomeType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyIncome_PropertyModels_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PropertyModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyValuations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValuationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValuationAmount = table.Column<double>(type: "float", nullable: false),
                    ValuationAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyValuations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyValuations_PropertyModels_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PropertyModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyValuationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferPrice = table.Column<double>(type: "float", nullable: false),
                    SalePrice = table.Column<double>(type: "float", nullable: false),
                    AcceptedOffer = table.Column<bool>(type: "bit", nullable: false),
                    CompletedSale = table.Column<bool>(type: "bit", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FailureReason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyOffers_PropertyModels_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "PropertyModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyOffers_PropertyValuations_PropertyValuationId",
                        column: x => x.PropertyValuationId,
                        principalTable: "PropertyValuations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertySaleData_PropertyId",
                table: "PropertySaleData",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Mortgage_PropertyModelId",
                table: "Mortgage",
                column: "PropertyModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyExpenses_PropertyId",
                table: "PropertyExpenses",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyIncome_PropertyId",
                table: "PropertyIncome",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyOffers_PropertyId",
                table: "PropertyOffers",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyOffers_PropertyValuationId",
                table: "PropertyOffers",
                column: "PropertyValuationId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyValuations_PropertyId",
                table: "PropertyValuations",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mortgage_PropertyModels_PropertyModelId",
                table: "Mortgage",
                column: "PropertyModelId",
                principalTable: "PropertyModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyExpenses_Mortgage_MortgageId",
                table: "PropertyExpenses",
                column: "MortgageId",
                principalTable: "Mortgage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyExpenses_PropertyModels_PropertyId",
                table: "PropertyExpenses",
                column: "PropertyId",
                principalTable: "PropertyModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertySaleData_PropertyModels_PropertyId",
                table: "PropertySaleData",
                column: "PropertyId",
                principalTable: "PropertyModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mortgage_PropertyModels_PropertyModelId",
                table: "Mortgage");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyExpenses_Mortgage_MortgageId",
                table: "PropertyExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyExpenses_PropertyModels_PropertyId",
                table: "PropertyExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertySaleData_PropertyModels_PropertyId",
                table: "PropertySaleData");

            migrationBuilder.DropTable(
                name: "CompanyExpenses");

            migrationBuilder.DropTable(
                name: "PropertyIncome");

            migrationBuilder.DropTable(
                name: "PropertyOffers");

            migrationBuilder.DropTable(
                name: "PropertyValuations");

            migrationBuilder.DropIndex(
                name: "IX_PropertySaleData_PropertyId",
                table: "PropertySaleData");

            migrationBuilder.DropIndex(
                name: "IX_Mortgage_PropertyModelId",
                table: "Mortgage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyModels",
                table: "PropertyModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyExpenses",
                table: "PropertyExpenses");

            migrationBuilder.DropIndex(
                name: "IX_PropertyExpenses_PropertyId",
                table: "PropertyExpenses");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Mortgage");

            migrationBuilder.DropColumn(
                name: "PropertyModelId",
                table: "Mortgage");

            migrationBuilder.DropColumn(
                name: "Owned",
                table: "PropertyModels");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PropertyExpenses");

            migrationBuilder.RenameTable(
                name: "PropertyModels",
                newName: "PropertyModel");

            migrationBuilder.RenameTable(
                name: "PropertyExpenses",
                newName: "PropertyExpense");

            migrationBuilder.RenameColumn(
                name: "AnnualPromotionalInterestRate",
                table: "Mortgage",
                newName: "InterestRate");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyExpenses_MortgageId",
                table: "PropertyExpense",
                newName: "IX_PropertyExpense_MortgageId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "PropertyExpense",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyModel",
                table: "PropertyModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyExpense",
                table: "PropertyExpense",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    OfferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfferPrice = table.Column<double>(type: "float", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyExpense_Mortgage_MortgageId",
                table: "PropertyExpense",
                column: "MortgageId",
                principalTable: "Mortgage",
                principalColumn: "Id");
        }
    }
}
