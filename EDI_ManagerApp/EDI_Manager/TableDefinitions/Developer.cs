using System.ComponentModel.DataAnnotations;

namespace EDI_Manager
{
    public class Developer
    {
        public int DeveloperId { get; set; }

        [StringLength(30)]
        public string DeveloperFirstName { get; set; } = string.Empty;

        [StringLength(30)]
        public string DeveloperLastName { get; set; } = string.Empty;

        [StringLength(200)]
        public string DeveloperMail{ get; set; } = string.Empty;

        [StringLength(30)]
        public string DeveloperRole { get; set; } = string.Empty;
    }
}
