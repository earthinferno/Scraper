using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SeeTicketsScraper.Models;

namespace SeeTicketsScraper.Services
{
    public class JsonEventExporter : IEventExporter
    {

        public void ExportEvents(List<EventModel> eventData)
        {
            Console.WriteLine(JsonConvert.SerializeObject(eventData));
        }
    }
}
