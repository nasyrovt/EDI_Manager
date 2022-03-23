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

        [StringLength(100)]
        public string FeedName { get; set; } = string.Empty;
        
        //File-related
        public int SourceFileId { get; set; }

        public File? SourceFile { get; set; }

        public int TargetFileMimeId { get; set; }

        public FileMime? TargetFileType { get; set; }

        public bool InProduction { get; set; } = false;
        public bool IsChangesOnly { get; set; } = false;


        //Frequency related properties
        public int FeedFrequencyId { get; set; }  
        public FeedFrequency? FeedFrequency { get; set; }

        [Range(1, 31)]
        public int? BusinessDayOfMonth { get; set; }

        [Range(1, 13)]
        public int? FrequencyTimes { get; set; }
        public string Series { get; set; } = string.Empty;

        [Range(1, 8)]
        public int WeeklyRecurDay { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string? EndDate { get; set; } = string.Empty;

        //Security properties
        public int FeedSecurityTypeId { get; set; }
        public FeedSecurityType? FeedSecurityType { get; set; }
        
        public string? ZipPassword { get; set; } = string.Empty;
        
        public string? PGPPassword { get; set; } = string.Empty;
        
        //Client-Carriers
        public int ClientId { get; set; }

        public Client? Client { get; set; }

        public int CarrierId { get; set; }

        public Carrier? Carrier { get; set; }

        public int FTPAccountId { get; set; }

        public FTPAccount? FTPAccount { get; set; }

        //Additional properties
        public int DeveloperId { get; set; }
        
        public Developer? Developer { get; set; }

    }
}
