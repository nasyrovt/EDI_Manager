using System.ComponentModel.DataAnnotations;


namespace EDI_Manager
{
    public class Feed
    {
        public int FeedId { get; set; }

        [StringLength(20)]
        public string FeedName { get; set; } = string.Empty;

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int SourceFileId { get; set; }
        
        public File SourceFile { get; set; }

        public int TargetFileId { get; set; }

        public File TargetFile { get; set; }

        [StringLength(200)]
        public string TargetEmails { get; set; } = string.Empty;

        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }

        [StringLength(20)]
        public string FTPServerName { get; set; } = string.Empty;

        [StringLength(20)]
        public string FTPUserName { get; set; } = string.Empty;
    }
}
