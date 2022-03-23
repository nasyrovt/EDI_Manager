using System.ComponentModel.DataAnnotations;

namespace EDI_Manager
{
    public class Client
    {
        public int ClientId { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; } = string.Empty;
        public int ClientTaxId { get; set; }

        [StringLength(200)]
        public string ContactName { get; set; } = string.Empty;

        [StringLength(100)]
        public string ContactMails{ get; set; } = string.Empty;

        [StringLength(100)]
        public string ContactPhoneNumbers { get; set; } = string.Empty;

    }
}
