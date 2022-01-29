using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_Maria_Eganyan.LogInfo
{
    interface ILoger
    {
        public void LogError(string message);
        public void LogWarning(string message);
        public void LogInformation(string message);
    }
}
