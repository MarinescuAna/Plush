using System;

namespace Plush.ApplicationLogger
{
    public interface ILoggerService
    {
        void LogError(string path, string message);
    }
}
