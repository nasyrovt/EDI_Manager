using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EDI_Manager.TableDefinitions
{
    public enum PlatformName
    {
        PlanSource,
        ArcoroIHR,
        eNavigator,
        benefitsConnect,
        Zoho,
        IntegrationManager
    }
    public class Platform
    {
        public int PlatformId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PlatformName PlatformName { get; set; }
    }
}
