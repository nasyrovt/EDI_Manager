using System.ComponentModel.DataAnnotations;

namespace EDI_Manager
{
    public class File
    {
        public int FileId { get; set; }

        [StringLength(20)]
        public string FileName { get; set; } = string.Empty;
        public int FileTypeId { get; set; }
        public FileType? FileType { get; set; }
        public int Size { get; set; }
    }
}
