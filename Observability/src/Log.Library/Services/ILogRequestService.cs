using LogLibrary.Structs;

namespace Log.Library.Services
{
    public interface ILogRequestService
    {
        public LogRequestObject Log { get; set; }
    }
}
