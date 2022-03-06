using System.ComponentModel.DataAnnotations;

namespace EDI_Manager
{
    public class Client
    {
        public int ClientId { get; set; }

        [StringLength(20)]
        public string ClientName { get; set; }

        [StringLength(20)]
        public string ClientSurName { get; set; }
        public int ClientAge { get; set; }

        [StringLength(200)]
        public string ClientAdress { get; set; }

        [StringLength(10)]
        public string ProfileCreationDate { get; set; }

    }
}
