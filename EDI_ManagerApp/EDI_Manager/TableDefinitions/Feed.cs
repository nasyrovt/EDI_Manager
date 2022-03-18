using EDI_Manager.TableDefinitions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace EDI_Manager
{
    public class Feed
    {
        public int FeedId { get; set; }

        [StringLength(20)]
        public string FeedName { get; set; } = string.Empty;

        public int FeedStatusId { get; set; }
        public FeedStatus? FeedStatus { get; set; }
        public int FeedFileChangesId { get; set; }
        public FeedFileChanges? FeedFileChanges { get; set; }

        [Range(1, 31)]
        public int BusinessDayOfMonth { get; set; }

        public int FeedFrequencyId { get; set; }  
        public FeedFrequency? FeedFrequency { get; set; }

        [Range(0, 12)]
        public int FrequencyTimes { get; set; }

        public int WeeklyRecurDay { get; set; }

        public int FeedSecurityTypeId { get; set; }
        public FeedSecurityType? FeedSecurityType { get; set; }
        
        public string? ZipPassword { get; set; } = string.Empty;
        
        public string? PGPPassword { get; set; } = string.Empty;

        public int ClientId { get; set; }

        public Client? Client { get; set; }

        public int SourceFileId { get; set; }
        
        public File? SourceFile { get; set; }

        public int TargetFileTypeId { get; set; }

        public FileType? TargetFileType { get; set; }

        public int CarrierId { get; set; }
        
        public Carrier? Carrier { get; set; }

        public int DeveloperId { get; set; }
        
        public Developer? Developer { get; set; }

        public int FTPAccountId { get; set; }
        
        public FTPAccount? FTPAccount { get; set; }
    }
}
