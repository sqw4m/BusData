using System.IO;

namespace DITypeFilterSample.Services
{
    public class Logger
    {
        public string LogFilePath { get; set; } = "App_Data/log.txt";

        public void WriteLog(string log)
        {
            StreamWriter streamWriter = new StreamWriter(LogFilePath, true);

            // context.Exception - исключение, из-за которого сработал фильтр
            streamWriter.WriteLine(log);
            streamWriter.WriteLine();

            streamWriter.Close();
        }
    }
}
