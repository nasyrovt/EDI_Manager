using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EDI_Manager.TableDefinitions
{
    public class Platform
    {
        public int PlatformId { get; set; }
        public string PlatformName { get; set; } = string.Empty;
    }
}
