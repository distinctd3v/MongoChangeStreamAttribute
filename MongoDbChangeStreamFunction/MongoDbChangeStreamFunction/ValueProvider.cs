using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace MongoDbChangeStreamFunction
{
    public class ValueProvider : IValueProvider
    {
        private readonly object _value;

        public ValueProvider(object value)
        {
            _value = value;
        }

        public Type Type => _value?.GetType() ?? typeof(object);

        public Task<object> GetValueAsync()
        {
            return Task.FromResult(_value);
        }

        public string ToInvokeString()
        {
            return _value?.ToString() ?? string.Empty;
        }
    }
}
