using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class Elections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SourceFilePath",
                table: "Spouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SourceFilePath",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SourceFilePath",
                table: "Children",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    ElectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Benefit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EEPostaxPremium = table.Column<float>(type: "real", nullable: true),
                    EEPretaxPremium = table.Column<float>(type: "real", nullable: true),
                    EmployerAnnualAmount = table.Column<int>(type: "int", nullable: true),
                    EmployerMonthlyAmount = table.Column<int>(type: "int", nullable: true),
                    ChangeEffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DemographicEffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SignatureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginalEffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElectionEffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PriorEffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoverageTerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoverageTerminationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaivePlanTerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriberAnnual = table.Column<int>(type: "int", nullable: true),
                    EEPremium = table.Column<float>(type: "real", nullable: true),
                    Volume = table.Column<int>(type: "int", nullable: true),
                    RequestedVolume = table.Column<int>(type: "int", nullable: true),
                    RequestedSubscriberMonthly = table.Column<int>(type: "int", nullable: true),
                    GroupNumber = table.Column<int>(type: "int", nullable: true),
                    PriorGroupNumber = table.Column<int>(type: "int", nullable: true),
                    ExportMappingCode = table.Column<int>(type: "int", nullable: true),
                    HSAContributionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HSAERLumpSum = table.Column<int>(type: "int", nullable: true),
                    HSALumpSumPayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IncrementsOrPercentage = table.Column<int>(type: "int", nullable: true),
                    CarrierEffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorCarrierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorMemberId = table.Column<int>(type: "int", nullable: true),
                    PriorTerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestedEmployerAnnualAmount = table.Column<int>(type: "int", nullable: true),
                    RequestedEmployerMonthlyAmount = table.Column<int>(type: "int", nullable: true),
                    RequestedIncrementsOrPercentage = table.Column<int>(type: "int", nullable: true),
                    RequestedLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedSubscriberAnnual = table.Column<int>(type: "int", nullable: true),
                    SubscriberMonthly = table.Column<int>(type: "int", nullable: true),
                    SubscriberYTD = table.Column<int>(type: "int", nullable: true),
                    ERPremium = table.Column<int>(type: "int", nullable: true),
                    BillingFee = table.Column<float>(type: "real", nullable: true),
                    BillingFee2 = table.Column<float>(type: "real", nullable: true),
                    BillingPremium = table.Column<float>(type: "real", nullable: true),
                    CreateMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CobraMappingCode = table.Column<int>(type: "int", nullable: true),
                    DomesticPartnerOrgPremiumAmount = table.Column<int>(type: "int", nullable: true),
                    DomesticPartnerSubscriberPremiumAmount = table.Column<int>(type: "int", nullable: true),
                    EffectiveDateForOrganizationYTD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EffectiveDateForSubscriberYTD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImputedIncome = table.Column<float>(type: "real", nullable: true),
                    MaximumVolumeAllowedAmount = table.Column<int>(type: "int", nullable: true),
                    OrganizationYTD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayrollMappingCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.ElectionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropColumn(
                name: "SourceFilePath",
                table: "Spouses");

            migrationBuilder.DropColumn(
                name: "SourceFilePath",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SourceFilePath",
                table: "Children");
        }
    }
}
