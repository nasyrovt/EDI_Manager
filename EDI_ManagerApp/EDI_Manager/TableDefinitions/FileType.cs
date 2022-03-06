using System.ComponentModel.DataAnnotations;

namespace EDI_Manager.TableDefinitions
{
    public class FileType
    {
        public int FileTypeId { get; set; }

        [StringLength(10)]
        public string FileTypeName { get; set; } = string.Empty;
    }
}
