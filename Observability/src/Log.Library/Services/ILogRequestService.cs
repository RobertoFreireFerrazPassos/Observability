namespace LogLibrary.Services
{
    public interface ILogRequestService
    {
        public Dictionary<string, object> AdditionalData { get; set; }
    }
}
