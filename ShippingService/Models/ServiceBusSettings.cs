using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Models
{
    public class ServiceBusSettings
    {
        public string ConnectionString { get; set; }
        public List<ServiceBusConsumerSettings> Consumers { get; set; }
    }

    public class ServiceBusConsumerSettings{
        public string Topic { get; set; }
        public string Subscription { get; set; }
    }
}