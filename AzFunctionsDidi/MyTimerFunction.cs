using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzFunctionsDidi
{
    public static class MyTimerFunction
    {
        [FunctionName("MyTimerFunction")]
        public static void Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, ILogger log)
        {
             log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
