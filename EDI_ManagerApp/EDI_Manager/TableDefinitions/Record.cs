using CsvHelper.Configuration;
using EDI_Manager.Utilities;

namespace EDI_Manager.TableDefinitions
{
    public class Record
    {
        public string? CompanyName  { get; set; }
        public string? RecordType { get; set; }
        public string? EnrollmentMethod { get; set; }
        public int? MemberSsn { get; set; }
        public string? Relationship { get; set; } 
        public string? MemberLastName { get; set; }
        public string? MemberFirstName { get; set; }
        public string? MemberMiddleName { get; set; }
        public int? Ssn { get; set; }
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
        public int? MemberZip { get; set; }
        public string? Cell { get; set; }
        public string? Email { get; set; }
        public string? BusinessTitle { get; set; } 
        public string? Union { get; set; }
        public int? HomePhone { get; set; }
        public int? HoursPerWeek { get; set; }
        public string? PreferredLanguage { get; set; }
        public bool? IsTestEmployee { get; set; }
        public bool? IsTobaccoUser { get; set; }
        public string? UserName { get; set; }
        public string? QMCSO { get; set; }
        public DateTime? VerificationExpiresOn { get; set; }
        public bool? IsVerified { get; set; }
        public string? MemberCountry { get; set; }
        public string? Benefit { get; set; }
        public string? Plan { get; set; }
        public string? Level { get; set; }
        public float? EEPostaxPremium { get; set; }
        public float? EEPretaxPremium { get; set; }
        public int? EmployerAnnualAmount { get; set; }
        public int? EmployerMonthlyAmount { get; set; }
        public DateTime? ChangeEffectiveDate { get; set; }
        public DateTime? DemographicEffectiveDate { get; set; }
        public DateTime? SignatureDate { get; set; }
        public DateTime? OriginalEffectiveDate { get; set; }
        public DateTime? ElectionEffectiveDate { get; set; }
        public DateTime? PriorEffectiveDate { get; set; }
        public DateTime? CoverageTerminationDate { get; set; }
        public string? CoverageTerminationReason { get; set; }
        public DateTime? WaivePlanTerminationDate { get; set; }
        public int? SubscriberAnnual { get; set; }
        public float? EEPremium { get; set; }
        public int? Volume { get; set; }
        public int? RequestedVolume { get; set; }
        public int? RequestedSubscriberMonthly { get; set; }
        public int? GroupNumber { get; set; }
        public int? PriorGroupNumber { get; set; }
        public int? ExportMappingCode { get; set; }
        public DateTime? HSAContributionEndDate { get; set; }
        public int? HSAERLumpSum { get; set; }
        public DateTime? HSALumpSumPayDate { get; set; }
        public int? IncrementsOrPercentage { get; set; }
        public DateTime? CarrierEffectiveDate { get; set; }
        public string? Carrier { get; set; }
        public string? PriorCarrierName { get; set; }
        public int? PriorMemberId { get; set; }
        public DateTime? PriorTerminationDate { get; set; }
        public int? RequestedEmployerAnnualAmount { get; set; }
        public int? RequestedEmployerMonthlyAmount { get; set; }
        public int? RequestedIncrementsOrPercentage { get; set; }
        public string? RequestedLevel { get; set; }
        public string? RequestedPlan { get; set; }
        public int? RequestedSubscriberAnnual { get; set; }
        public int? SubscriberMonthly { get; set; }
        public int? SubscriberYTD { get; set; }
        public int? ERPremium { get; set; }
        public float? BillingFee { get; set; }
        public float? BillingFee2 { get; set; }
        public float? BillingPremium { get; set; }
        public string? CreateMode { get; set; }
        public int? CobraMappingCode { get; set; }
        public int? DomesticPartnerOrgPremiumAmount { get; set; }
        public int? DomesticPartnerSubscriberPremiumAmount { get; set; }
        public DateTime? EffectiveDateForOrganizationYTD { get; set; }
        public DateTime? EffectiveDateForSubscriberYTD { get; set; }
        public float? ImputedIncome { get; set; }
        public int? MaximumVolumeAllowedAmount { get; set; }
        public string? OrganizationYTD { get; set; }
        public int? PayrollMappingCode { get; set; }
    }

    public class RecordClassMap : ClassMap<Record>
    {
        public RecordClassMap()
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
            Map(employee => employee.MemberHireDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Hire Date");
            Map(employee => employee.OriginalHireDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Original Hire Date");
            Map(employee => employee.Division).Name("Division");
            Map(employee => employee.Location).Name("Location");
            Map(employee => employee.IsCertified).Name("Class");
            Map(employee => employee.EventDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Event Date");
            Map(employee => employee.EventReason).Name("Event Reason");
            Map(employee => employee.MemberTerminationDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Member Termination Date");
            Map(employee => employee.MemberTerminationReason).Name("Member Termination Reason");
            Map(employee => employee.TerminationDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Termination Date");
            Map(employee => employee.TerminationReason).Name("Termination Reason");
            Map(employee => employee.IsVoluntaryTermination).Name("Voluntary Termination");
            Map(employee => employee.EmployeeStatus).Name("Employee Status");
            Map(employee => employee.EmploymentLevel).Name("Employment Level");
            Map(employee => employee.EmploymentStatus).Name("Employment Status");
            Map(employee => employee.EmploymentStatusEndDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Employment Status End Date");
            Map(employee => employee.EmployeeNumber).Name("Employee Number");
            Map(employee => employee.EmploymentStatusStartDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Employment Status Start Date");
            Map(employee => employee.EligibilityPeriodEndDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Eligibility Period End Date");
            Map(employee => employee.EligibilityPeriodStartDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Eligibility Period Start Date");
            Map(employee => employee.StatusChangedAt).TypeConverter(new DateConverter("yyyyMMdd")).Name("Status Changed At");
            Map(employee => employee.StatusEndDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Status End Date");
            Map(employee => employee.StatusStartDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Status Start Date");
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
            Map(employee => employee.BusinessTitle).Name("Business Title");
            Map(employee => employee.Union).Name("Union");
            Map(employee => employee.HomePhone).Name("Home Phone");
            Map(employee => employee.HoursPerWeek).Name("Hours Per Week");
            Map(employee => employee.PreferredLanguage).Name("Preferred Language");
            Map(employee => employee.IsTestEmployee).Name("Test Employee");
            Map(employee => employee.IsTobaccoUser).Name("Tobacco User");
            Map(employee => employee.UserName).Name("User Name");
            Map(employee => employee.QMCSO).Name("QMCSO");
            Map(employee => employee.VerificationExpiresOn).TypeConverter(new DateConverter("yyyyMMdd")).Name("Verification Expires On");
            Map(employee => employee.IsVerified).Name("Verified");
            Map(employee => employee.MemberCountry).Name("Member Country");

            Map(employee => employee.Benefit).Name("Benefit");
            Map(employee => employee.Plan).Name("Plan");
            Map(employee => employee.Level).Name("Level");
            Map(employee => employee.EEPostaxPremium).Name("EE Postax Premium");
            Map(employee => employee.EEPretaxPremium).Name("EE Pretax Premium");
            Map(employee => employee.EmployerAnnualAmount).Name("Employer Annual Amount");
            Map(employee => employee.EmployerMonthlyAmount).Name("Employer Monthly Amount");
            Map(employee => employee.ChangeEffectiveDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Change Effective Date");
            Map(employee => employee.DemographicEffectiveDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Demographic Effective Date");
            Map(employee => employee.SignatureDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Signature Date");
            Map(employee => employee.OriginalEffectiveDate).TypeConverter(new DateConverter("yyyyMMdd")).Name("Original Effective Date");
            Map(employee => employee.ElectionEffectiveDate).Name("Election Effective date").TypeConverter(new DateConverter("yyyyMMdd"));
            Map(employee => employee.PriorEffectiveDate).Name("Prior Effective Date").TypeConverter(new DateConverter("yyyyMMdd"));
            Map(employee => employee.CoverageTerminationDate).Name("Coverage Termination Date").TypeConverter(new DateConverter("yyyyMMdd"));
            Map(employee => employee.CoverageTerminationReason).Name("Coverage Termination Reason");
            Map(employee => employee.WaivePlanTerminationDate).Name("Waive Plan Termination Date").TypeConverter(new DateConverter("yyyyMMdd"));
            Map(employee => employee.SubscriberAnnual).Name("Subscriber Annual");
            Map(employee => employee.EEPremium).Name("EE Premium");
            Map(employee => employee.Volume).Name("Volume");
            Map(employee => employee.RequestedVolume).Name("Requested Volume");
            Map(employee => employee.RequestedSubscriberMonthly).Name("Requested Subscriber Monthly");
            Map(employee => employee.GroupNumber).Name("Group Number");
            Map(employee => employee.PriorGroupNumber).Name("Prior Group Number");
            Map(employee => employee.ExportMappingCode).Name("Export Mapping Code");
            Map(employee => employee.HSAContributionEndDate).Name("HSA Contribution End Date").TypeConverter(new DateConverter("yyyyMMdd"));
            Map(employee => employee.HSAERLumpSum).Name("HSA ER Lump Sum");
            Map(employee => employee.HSALumpSumPayDate).Name("HSA Lump Sum Pay Date").TypeConverter(new DateConverter("yyyyMMdd"));
            Map(employee => employee.IncrementsOrPercentage).Name("Increments or %");
            Map(employee => employee.CarrierEffectiveDate).Name("Carrier Effective Date").TypeConverter(new DateConverter("yyyyMMdd"));
            Map(employee => employee.Carrier).Name("Carrier");
            Map(employee => employee.PriorCarrierName).Name("Prior Carrier Name");
            Map(employee => employee.PriorMemberId).Name("Prior Member ID");
            Map(employee => employee.PriorTerminationDate).Name("Prior Termination Date").TypeConverter(new DateConverter("yyyyMMdd"));
            Map(employee => employee.RequestedEmployerAnnualAmount).Name("Requested Employer Annual Amount");
            Map(employee => employee.RequestedEmployerMonthlyAmount).Name("Requested Employer Monthly Amount");
            Map(employee => employee.RequestedIncrementsOrPercentage).Name("Requested Increments or %");
            Map(employee => employee.RequestedLevel).Name("Requested Level");
            Map(employee => employee.RequestedPlan).Name("Requested Plan");
            Map(employee => employee.RequestedSubscriberAnnual).Name("Requested Subscriber Annual");
            Map(employee => employee.SubscriberMonthly).Name("Subscriber Monthly");
            Map(employee => employee.SubscriberYTD).Name("Subscriber YTD (Year To Date)");
            Map(employee => employee.ERPremium).Name("ER Premium");
            Map(employee => employee.BillingFee).Name("Billing Fee");
            Map(employee => employee.BillingFee2).Name("Billing Fee 2");
            Map(employee => employee.BillingPremium).Name("Billing Premium");
            Map(employee => employee.CreateMode).Name("Auto/Default Create Mode");
            Map(employee => employee.CobraMappingCode).Name("Cobra Mapping Code");
            Map(employee => employee.DomesticPartnerOrgPremiumAmount).Name("Domestic Partner Org Premium Amount");
            Map(employee => employee.DomesticPartnerSubscriberPremiumAmount).Name("Domestic Partner Subscriber Premium Amount");
            Map(employee => employee.EffectiveDateForOrganizationYTD).Name("Effective Date For Organization YTD (Year To Date)");
            Map(employee => employee.EffectiveDateForSubscriberYTD).Name("Effective Date For Subscriber YTD (Year To Date)");
            Map(employee => employee.ImputedIncome).Name("Imputed Income");
            Map(employee => employee.MaximumVolumeAllowedAmount).Name("Maximum Volume Allowed Amount");
            Map(employee => employee.OrganizationYTD).Name("Organization YTD (Year To Date)");
            Map(employee => employee.PayrollMappingCode).Name("Payroll Mapping Code");
        }
    }
}
