using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingService.Models
{
    public class ServiceBusSettings
    {
        public string ConnectionString { get; set; }
        public string TopicName { get; set; }
    }
}