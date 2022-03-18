namespace EDI_Manager.TableDefinitions
{

    public class Carrier
    {
        public int CarrierId{ get; set; }
        public string CarrierName{ get; set; } = string.Empty;
        public int CarrierTypeId { get; set; }
        public CarrierType? CarrierType { get; set; }
        public int CarrierTaxId { get; set; } 
        public int GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public int MasterPolicyNumber { get; set; }
        public string Adress1 { get; set; } = string.Empty;
        public string? Adress2 { get; set; } = string.Empty;
        public string? WebSite { get; set; } = string.Empty;
        public string Phones { get; set; } = string.Empty;

    }
}
