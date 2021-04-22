using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzFunctionsDidi
{
    public static class MyServiceBusQueueTrigger
    {
        [FunctionName("MyServiceBusQueueTrigger")]
        public static void Run([ServiceBusTrigger("dariiaqueue11", Connection = "")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            
            var jsonTextReader = new JsonTextReader(new StringReader(myQueueItem));
            var person = JsonSerializer.CreateDefault().Deserialize<Person>(jsonTextReader);
            
            log.LogInformation($"Service Bus Person recieved: {person.Name} {person.Age}");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
