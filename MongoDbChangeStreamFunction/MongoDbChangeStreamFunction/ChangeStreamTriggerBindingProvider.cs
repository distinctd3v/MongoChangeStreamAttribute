using Microsoft.Azure.WebJobs.Host.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbChangeStreamFunction
{
    public class ChangeStreamTriggerBindingProvider : ITriggerBindingProvider
    {
        //Next, the ChangeStreamTriggerBindingProvider is responsible for detecting this attribute
        //in your function's parameters and creating the appropriate trigger binding.
        //ChangeStreamTriggerBindingProvider detects the ChangeStreamTriggerAttribute
        //applied to your function parameter and creates a corresponding trigger binding.

        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            ParameterInfo parameter = context.Parameter;
            ChangeStreamTriggerAttribute attribute = parameter.GetCustomAttribute<ChangeStreamTriggerAttribute>(inherit: false);

            if (attribute != null)
            {
                ITriggerBinding binding = new ChangeStreamTriggerBinding(parameter, attribute.ConnectionStringSetting, attribute.DatabaseName, attribute.CollectionName);
                return Task.FromResult(binding);
            }

            return Task.FromResult<ITriggerBinding>(null);
        }
    }
}
