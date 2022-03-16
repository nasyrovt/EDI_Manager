namespace EDI_Manager.TableDefinitions
{
    public class FTPAccount
    {
        public int FTPAccountId { get; set; }
        public string FTPHost { get; set; } = string.Empty;
        public string FTPUser { get; set; } = string.Empty;
        public string FTPPassword { get; set; } = string.Empty;
        public string FTPDirectory { get; set; } = string.Empty;
        public string FTPType { get; set; } = string.Empty;
        public int FTPPort { get; set; }
    }
}
