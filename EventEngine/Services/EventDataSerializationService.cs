﻿using EventEngine.Interfaces.Events;
using EventEngine.Interfaces.Services;
using Newtonsoft.Json;

namespace EventEngine.Services
{
    public class EventDataSerializationService : IEventDataSerializationService
    {
        public string Serialize(IEventData eventData)
        {
            return JsonHelper.Serializer.SerializeObject(eventData, Formatting.Indented);
        }
    }
}
