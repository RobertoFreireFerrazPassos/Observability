using LogLibrary.Structs;

namespace LogLibrary.Services
{
    public class LogRequestService : ILogRequestService
    {
        public Dictionary<string, object> AdditionalData { get; set; }
    }
}
