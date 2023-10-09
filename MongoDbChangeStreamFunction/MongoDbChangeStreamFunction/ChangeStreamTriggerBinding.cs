using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbChangeStreamFunction
{
    public class ChangeStreamTriggerBinding : ITriggerBinding
    {

        private readonly ParameterInfo _parameter;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<BsonDocument> _collection;

        public ChangeStreamTriggerBinding(ParameterInfo parameter, string connectionStringSetting, string databaseName, string collectionName)
        {
            _parameter = parameter;
            var connectionString = Environment.GetEnvironmentVariable(connectionStringSetting);
            _mongoClient = new MongoClient(connectionString);
            var database = _mongoClient.GetDatabase(databaseName);
            _collection = database.GetCollection<BsonDocument>(collectionName);
        }

        public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            // Implement binding logic here
            // ...

            return Task.FromResult<ITriggerData>(null);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new ParameterDescriptor
            {
                Name = _parameter.Name,
                DisplayHints = new ParameterDisplayHints
                {
                    Prompt = "MongoDB Change Stream trigger fired",
                    Description = "MongoDB Change Stream trigger fired",
                    DefaultValue = "MongoDB Change Stream trigger fired"
                }
            };
        }

        public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            throw new NotImplementedException();
        }

        public Type TriggerValueType => typeof(BsonDocument);

        public IReadOnlyDictionary<string, Type> BindingDataContract => throw new NotImplementedException();
    }
}



