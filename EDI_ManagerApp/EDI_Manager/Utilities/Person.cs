using CsvHelper.Configuration;
using EDI_Manager.Utilities;

namespace EDI_Manager.TableDefinitions
{
    public abstract class Person
    {
        protected virtual int Id { get; set; }
        public string SourceFilePath { get; set; } = string.Empty;
        public string? CompanyName { get; set; }
        public string? RecordType { get; set; }
        public string? EnrollmentMethod { get; set; }
        public long? MemberSsn { get; set; }
        public string? Relationship { get; set; }
        public string? MemberLastName { get; set; }
        public string? MemberFirstName { get; set; }
        public string? MemberMiddleName { get; set; }
        public long? Ssn { get; set; }
        public string? MemberGender { get; set; }
        public string? MaritalStatus { get; set; }
        public DateTime? MemberBirthDate { get; set; }
        public DateTime? MemberHireDate { get; set; }
        public DateTime? OriginalHireDate { get; set; }
        public string? Division { get; set; }
        public string? Location { get; set; }
        public string? IsCertified { get; set; }
        public DateTime? EventDate { get; set; }
        public string? EventReason { get; set; }
        public DateTime? MemberTerminationDate { get; set; }
        public string? MemberTerminationReason { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string? TerminationReason { get; set; }
        public bool? IsVoluntaryTermination { get; set; }
        public string? EmployeeStatus { get; set; }
        public string? EmploymentLevel { get; set; }
        public string? EmploymentStatus { get; set; }
        public DateTime? EmploymentStatusEndDate { get; set; }
        public int? EmployeeNumber { get; set; }
        public DateTime? EmploymentStatusStartDate { get; set; }
        public DateTime? EligibilityPeriodEndDate { get; set; }
        public DateTime? EligibilityPeriodStartDate { get; set; }
        public DateTime? StatusChangedAt { get; set; }
        public DateTime? StatusEndDate { get; set; }
        public DateTime? StatusStartDate { get; set; }
        public int? SubscriberID { get; set; }
        public string? EmployeeType { get; set; }
        public float? BenefitSalary { get; set; }
        public string? PayrollSchedule { get; set; }
        public int? PayRate { get; set; }
        public string? PayType { get; set; }
        public string? MemberAddress1 { get; set; }
        public string? MemberAddress2 { get; set; }
        public string? MemberCity { get; set; }
        public string? MemberState { get; set; }
        public string? MemberZip { get; set; } = string.Empty;
        public string? Cell { get; set; }
        public string? Email { get; set; }
        public string? BusinessTitle { get; set; }
        public string? Union { get; set; }
        public long? HomePhone { get; set; }
        public int? HoursPerWeek { get; set; }
        public string? PreferredLanguage { get; set; }
        public bool? IsTestEmployee { get; set; }
        public bool? IsTobaccoUser { get; set; }
        public string? UserName { get; set; }
        public string? QMCSO { get; set; }
        public DateTime? VerificationExpiresOn { get; set; }
        public bool? IsVerified { get; set; }
        public string? MemberCountry { get; set; }

    }
}
