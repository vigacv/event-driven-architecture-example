using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingService.Models
{
    public class ServiceBusSettings
    {
        public string ConnectionString { get; set; }
        public string ConsumeTopic { get; set; }
        public string PublishTopic { get; set; }
        public string Subscription { get; set; }
    }
}