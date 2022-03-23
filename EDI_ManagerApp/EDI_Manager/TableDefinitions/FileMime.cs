using System.ComponentModel.DataAnnotations;

namespace EDI_Manager
{
    public class FileMime
    {
        public int FileMimeId { get; set; }

        [StringLength(10)]
        public string FileMimeName { get; set; } = string.Empty;
    }
}
