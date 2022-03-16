using EDI_Manager.TableDefinitions;
using System.ComponentModel.DataAnnotations;


namespace EDI_Manager
{
    public class Feed
    {
        public int FeedId { get; set; }

        [StringLength(20)]
        public string FeedName { get; set; } = string.Empty;

        public int ClientId { get; set; }

        public Client? Client { get; set; }

        public int SourceFileId { get; set; }
        
        public File? SourceFile { get; set; }

        public int TargetFileTypeId { get; set; }

        public FileType? TargetFileType { get; set; }

        [StringLength(200)]
        public string TargetEmails { get; set; } = string.Empty;

        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; }

        public int? FTPAccountId { get; set; }
        public FTPAccount? FTPAccount { get; set; }
    }
}
