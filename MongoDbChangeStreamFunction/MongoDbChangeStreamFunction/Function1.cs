using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MongoDB.Driver;
using System.Collections;

namespace MongoDbChangeStreamFunction
{
    public static class Function1
    {
        //Here, ProcessChanges is your function, and it will be triggered
        //whenever there are changes in the specified MongoDB collection.
        //The BsonDocument parameter changeEventData will contain the
        //details of the change event from MongoDB.

        //With these steps, your function should be triggered whenever there are changes
        //in the specified MongoDB collection, and the changeEventData parameter will contain
        //the details of the change event.

        [FunctionName("Function1")]
        public static void Run(
        [ChangeStreamTrigger(ConnectionStringSetting = "MongoDBConnection", DatabaseName = "YourDatabase", CollectionName = "YourCollection")] string change,
        ILogger log)
        {
            log.LogInformation($"Change received: {change}");
        }
    }
}
