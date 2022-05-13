using System;


namespace BlockChain.Core
{
    public interface  IClientLogger
    {
        public void LogDebug(string message);
        public void LogError(string message);
        public void LogError(string message, Exception ex);
    }
}
