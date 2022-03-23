using System.ComponentModel.DataAnnotations;

namespace EDI_Manager
{
    public class File
    {
        public int FileId { get; set; }

        [StringLength(20)]
        public string FileName { get; set; } = string.Empty;
        public int FileMimeId { get; set; }
        public FileMime? FileMime { get; set; }
        public int Size { get; set; }
    }
}
