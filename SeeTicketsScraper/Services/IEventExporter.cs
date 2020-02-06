using SeeTicketsScraper.Models;
using System.Collections.Generic;

namespace SeeTicketsScraper.Services
{
    public interface IEventExporter
    {
        public void ExportEvents(List<EventModel> eventData);
    }
}
