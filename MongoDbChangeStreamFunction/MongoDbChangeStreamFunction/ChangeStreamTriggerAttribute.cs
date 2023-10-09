using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbChangeStreamFunction
{
    //Firstly, the ChangeStreamTriggerAttribute defines the trigger attribute.
    //This attribute holds the necessary information about the MongoDB connection
    //and the collection to watch for changes.

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class ChangeStreamTriggerAttribute : Attribute
    {
        public string ConnectionStringSetting { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
