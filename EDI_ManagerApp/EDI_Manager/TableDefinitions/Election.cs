using EDI_Manager.Data;
using EDI_Manager.TableDefinitions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDI_Manager.Utilities
{
    public class Election
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public string ElectionId { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SourceFilePath { get; set; } = string.Empty;

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
}
