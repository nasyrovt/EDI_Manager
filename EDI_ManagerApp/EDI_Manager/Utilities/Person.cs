using CsvHelper.Configuration;
using EDI_Manager.Utilities;

namespace EDI_Manager.TableDefinitions
{
    public abstract class Person
    {
        protected virtual int Id { get; set; }
        public string CompanyName  { get; set; } = String.Empty;
        public string RecordType { get; set; } = String.Empty;
        public string EnrollmentMethod { get; set; } = String.Empty;
        public int MemberSsn { get; set; }
        public string Relationship { get; set; } = String.Empty;
        public string MemberLastName { get; set; } = String.Empty;
        public string MemberFirstName { get; set; } = String.Empty;
        public string MemberMiddleName { get; set; } = String.Empty; 
        public int Ssn { get; set; }
        public string MemberGender { get; set; } = String.Empty;
        public bool MaritalStatus { get; set; }
        public DateTime MemberBirthDate { get; set; }
        public DateTime MemberHireDate { get; set; }
        public DateTime OriginalHireDate { get; set; }
        public string Division { get; set; } = String.Empty; 
        public string Location { get; set; } = String.Empty; 
        public bool IsCertified { get; set; }
        public DateTime EventDate { get; set; }
        public string EventReason { get; set; } = String.Empty;
        public DateTime MemberTerminationDate { get; set; }
        public string MemberTerminationReason { get; set; } = String.Empty;
        public DateTime TerminationDate { get; set; }
        public string TerminationReason { get; set; } = String.Empty;
        public bool IsVoluntaryTermination { get; set; }
        public string EmployeeStatus { get; set; } = String.Empty;
        public string EmploymentLevel { get; set; } = String.Empty;
        public string EmploymentStatus { get; set; } = String.Empty;
        public DateTime EmploymentStatusEndDate { get; set; }
        public int EmployeeNumber { get; set; }
        public DateTime EmploymentStatusStartDate { get; set; }
        public DateTime EligibilityPeriodEndDate { get; set; }
        public DateTime EligibilityPeriodStartDate { get; set; }
        public DateTime StatusChangedAt { get; set; }
        public DateTime StatusEndDate { get; set; }
        public DateTime StatusStartDate { get; set; }
        public int SubscriberID { get; set; }
        public string EmployeeType { get; set; } = String.Empty; 
        public float BenefitSalary { get; set; }
        public string PayrollSchedule { get; set; } = String.Empty; 
        public int PayRate { get; set; }
        public string PayType { get; set; } = String.Empty;
        public string MemberAddress1 { get; set; } = String.Empty;
        public string MemberAddress2 { get; set; } = String.Empty;
        public string MemberCity { get; set; } = String.Empty;
        public string MemberState { get; set; } = String.Empty;
        public int MemberZip { get; set; }
        public string Cell { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string BusinessTitle { get; set; } = String.Empty;
        public string Union { get; set; } = String.Empty;
        public int HomePhone { get; set; }
        public int HoursPerWeek { get; set; }
        public string PreferredLanguage { get; set; } = String.Empty;
        public bool IsTestEmployee { get; set; }
        public bool IsTobaccoUser { get; set; }
        public string UserName { get; set; } = String.Empty;
        public string QMCSO { get; set; } = String.Empty;
        public DateTime VerificationExpiresOn { get; set; }
        public bool IsVerified { get; set; }
        public string MemberCountry { get; set; } = String.Empty;

    }

    public class PersonClassMap : ClassMap<Person>
    {
        public PersonClassMap()
        {
            Map(employee => employee.CompanyName).Name("Client Name");
            Map(employee => employee.RecordType).Name("Record Type");
            Map(employee => employee.EnrollmentMethod).Name("Enrollment Method");
            Map(employee => employee.MemberSsn).Name("Member SSN");
            Map(employee => employee.Relationship).Name("Relationship");
            Map(employee => employee.MemberLastName).Name("Member Last Name");
            Map(employee => employee.MemberFirstName).Name("Member First Name");
            Map(employee => employee.MemberMiddleName).Name("Member Middle Name");
            Map(employee => employee.Ssn).Name("SSN");
            Map(employee => employee.MemberGender).Name("Member Gender");
            Map(employee => employee.MaritalStatus).Name("Marital Status");
            Map(employee => employee.MemberBirthDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Member Birth Date");
            Map(employee => employee.MemberHireDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Member Hire Date");
            Map(employee => employee.OriginalHireDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Original Hire Date");
            Map(employee => employee.Division).Name("Division");
            Map(employee => employee.Location).Name("Location");
            Map(employee => employee.IsCertified).Name("Class");
            Map(employee => employee.EventDate).Name("Event Date");
            Map(employee => employee.EventReason).Name("Event Reason");
            Map(employee => employee.MemberTerminationDate).Name("Member Termination Date");
            Map(employee => employee.MemberTerminationReason).Name("Member Termination Reason");
            Map(employee => employee.TerminationDate).Name("Termination Date");
            Map(employee => employee.TerminationReason).Name("Termination Reason");
            Map(employee => employee.IsVoluntaryTermination).Name("Voluntary Termination");
            Map(employee => employee.EmployeeStatus).Name("Employee Status");
            Map(employee => employee.EmploymentLevel).Name("Employment Level");
            Map(employee => employee.EmploymentStatus).Name("Employment Status");
            Map(employee => employee.EmploymentStatusEndDate).Name("Employment Status End Date");
            Map(employee => employee.EmployeeNumber).Name("Employee Number");
            Map(employee => employee.EmploymentStatusStartDate).Name("Employment Status Start Date");
            Map(employee => employee.EligibilityPeriodEndDate).Name("Eligibility Period End Date");
            Map(employee => employee.EligibilityPeriodStartDate).Name("Eligibility Period Start Date");
            Map(employee => employee.StatusChangedAt).Name("Status Changed At");
            Map(employee => employee.StatusEndDate).Name("Status End Date");
            Map(employee => employee.StatusStartDate).Name("Status Start Date");
            Map(employee => employee.SubscriberID).Name("Subscriber ID");
            Map(employee => employee.EmployeeType).Name("Employee Type");
            Map(employee => employee.BenefitSalary).Name("Benefit Salary");
            Map(employee => employee.PayrollSchedule).Name("Payroll Schedule");
            Map(employee => employee.PayRate).Name("Pay Rate");
            Map(employee => employee.PayType).Name("Pay Type");
            Map(employee => employee.MemberAddress1).Name("Member Address 1");
            Map(employee => employee.MemberAddress2).Name("Member Address 2");
            Map(employee => employee.MemberCity).Name("Member City");
            Map(employee => employee.MemberState).Name("Member State");
            Map(employee => employee.MemberZip).Name("Member Zip");
            Map(employee => employee.Cell).Name("Cell");
            Map(employee => employee.Email).Name("E-mail");
            Map(employee => employee.BusinessTitle).Name("BusinessTitle");
            Map(employee => employee.Union).Name("Union");
            Map(employee => employee.HomePhone).Name("Home Phone");
            Map(employee => employee.HoursPerWeek).Name("Hours Per Week");
            Map(employee => employee.PreferredLanguage).Name("Preferred Language");
            Map(employee => employee.IsTestEmployee).Name("Test Employee");
            Map(employee => employee.IsTobaccoUser).Name("Tobacco User");
            Map(employee => employee.UserName).Name("User Name");
            Map(employee => employee.QMCSO).Name("QMCSO");
            Map(employee => employee.VerificationExpiresOn).Name("Verification Expires On");
            Map(employee => employee.IsVerified).Name("Verified");
            Map(employee => employee.MemberCountry).Name("Member Country");
        }
    }
}
