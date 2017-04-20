using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadTestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running loadtest. Press enter key to exit...");

            int startNumberOfClients = Convert.ToInt16(ConfigurationManager.AppSettings["StartNumberOfClient"]);
            int maxNumberOfClients = Convert.ToInt16(ConfigurationManager.AppSettings["MaxNumberOfClient"]);
            int stepNumberOfClients = Convert.ToInt16(ConfigurationManager.AppSettings["StepNumberOfClients"]);
            int stepTime = Convert.ToInt16(ConfigurationManager.AppSettings["StepTime"]); ;
            int messageInterval = Convert.ToInt16(ConfigurationManager.AppSettings["MessageInterval"]);
            int runDuration = Convert.ToInt16(ConfigurationManager.AppSettings["TestDurationAsSec"]);
            string baseUrl = ConfigurationManager.AppSettings["HubUrl"].ToString();
            string hubName = ConfigurationManager.AppSettings["HubName"].ToString();
            string serverCallback = ConfigurationManager.AppSettings["ServerSideCallBack"].ToString();

            string[] testPayload = new string[] { "key:key1, value:value1", "key:key2, value:value2" };

            ConnectionManager instance = new ConnectionManager();
            instance.Init(baseUrl, hubName, serverCallback, null);

            instance.GenerateLoad(startNumberOfClients, maxNumberOfClients, stepNumberOfClients,
                stepTime, messageInterval, runDuration);

            Console.ReadLine();
        }
    }
}
