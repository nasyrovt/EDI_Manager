using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDI_Manager.Migrations
{
    public partial class CsvFirstTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    ChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrollmentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberSsn = table.Column<int>(type: "int", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ssn = table.Column<int>(type: "int", nullable: false),
                    MemberGender = table.Column<bool>(type: "bit", nullable: false),
                    MaritalStatus = table.Column<bool>(type: "bit", nullable: false),
                    MemberBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberHireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OriginalHireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCertified = table.Column<bool>(type: "bit", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberTerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberTerminationReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminationReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVoluntaryTermination = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentStatusEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    EmploymentStatusStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EligibilityPeriodEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EligibilityPeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriberID = table.Column<int>(type: "int", nullable: false),
                    EmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BenefitSalary = table.Column<float>(type: "real", nullable: false),
                    PayrollSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayRate = table.Column<int>(type: "int", nullable: false),
                    PayType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberZip = table.Column<int>(type: "int", nullable: false),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Union = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhone = table.Column<int>(type: "int", nullable: false),
                    HoursPerWeek = table.Column<int>(type: "int", nullable: false),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTestEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsTobaccoUser = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QMCSO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    MemberCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.ChildId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrollmentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberSsn = table.Column<int>(type: "int", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ssn = table.Column<int>(type: "int", nullable: false),
                    MemberGender = table.Column<bool>(type: "bit", nullable: false),
                    MaritalStatus = table.Column<bool>(type: "bit", nullable: false),
                    MemberBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberHireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OriginalHireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCertified = table.Column<bool>(type: "bit", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberTerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberTerminationReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminationReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVoluntaryTermination = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentStatusEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    EmploymentStatusStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EligibilityPeriodEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EligibilityPeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriberID = table.Column<int>(type: "int", nullable: false),
                    EmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BenefitSalary = table.Column<float>(type: "real", nullable: false),
                    PayrollSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayRate = table.Column<int>(type: "int", nullable: false),
                    PayType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberZip = table.Column<int>(type: "int", nullable: false),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Union = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhone = table.Column<int>(type: "int", nullable: false),
                    HoursPerWeek = table.Column<int>(type: "int", nullable: false),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTestEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsTobaccoUser = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QMCSO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    MemberCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Spouses",
                columns: table => new
                {
                    SpouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrollmentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberSsn = table.Column<int>(type: "int", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ssn = table.Column<int>(type: "int", nullable: false),
                    MemberGender = table.Column<bool>(type: "bit", nullable: false),
                    MaritalStatus = table.Column<bool>(type: "bit", nullable: false),
                    MemberBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberHireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OriginalHireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCertified = table.Column<bool>(type: "bit", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberTerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberTerminationReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminationReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVoluntaryTermination = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentStatusEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    EmploymentStatusStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EligibilityPeriodEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EligibilityPeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriberID = table.Column<int>(type: "int", nullable: false),
                    EmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BenefitSalary = table.Column<float>(type: "real", nullable: false),
                    PayrollSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayRate = table.Column<int>(type: "int", nullable: false),
                    PayType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberZip = table.Column<int>(type: "int", nullable: false),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Union = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhone = table.Column<int>(type: "int", nullable: false),
                    HoursPerWeek = table.Column<int>(type: "int", nullable: false),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTestEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsTobaccoUser = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QMCSO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    MemberCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spouses", x => x.SpouseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Spouses");
        }
    }
}
