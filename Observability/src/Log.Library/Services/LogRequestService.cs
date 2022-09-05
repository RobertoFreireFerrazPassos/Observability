using LogLibrary.Structs;

namespace Log.Library.Services
{
    public class LogRequestService : ILogRequestService
    {
        private LogRequestObject log;

        LogRequestObject ILogRequestService.Log { 
            get => log;
            set => log = value;
        }
    }
}
