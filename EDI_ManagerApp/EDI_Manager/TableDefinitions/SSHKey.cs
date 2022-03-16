using System.ComponentModel.DataAnnotations;

namespace EDI_Manager
{
    public class SSHKey
    {
        public int SSHKeyId { get; set; }
        public string FTPHost { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;

    }
}
