using System.ComponentModel.DataAnnotations;

namespace EDI_Manager
{
    public class Developer
    {
        public int DeveloperId { get; set; }

        [StringLength(20)]
        public string DeveloperName { get; set; }

        [StringLength(20)]
        public string DeveloperSurName { get; set; }
        public int DeveloperAge { get; set; }

        [StringLength(30)]
        public string DeveloperAdress { get; set; }

        [StringLength(10)]
        public string HireDate { get; set; }
    }
}
