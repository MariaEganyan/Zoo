using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Zoo_Maria_Eganyan.LogInfo
{
    class MyLoger : ILoger
    {
        private string _path;
        private static MyLoger _loger;
        private MyLoger()
        {
            _path = DateTime.Now.Day.ToString();
            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }
        public void LogError(string message)
        {
            message = $"{DateTime.Now}-Error-{message}";
            Log(message);
        }

        public void LogInformation(string message)
        {
            message = $"{DateTime.Now}-Info-{message}";
            Log(message);
        }

        public void LogWarning(string message)
        {
            message = $"{DateTime.Now}-Warning-{message}";
            Log(message);
        }
        private void Log(string message)
        {
            File.AppendAllText(_path, $"{message}\n");
        }

        public static MyLoger GetInstance()
        {
            if (_loger == null)
             _loger = new MyLoger();
            return _loger;
        }
    }
}
