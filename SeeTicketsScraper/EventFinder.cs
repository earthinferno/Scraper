using SeeTicketsScraper.Services;
using SeeTicketsScraper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeTicketsScraper
{
    public class EventFinder
    {
        readonly IDocumentUtilty _documentUtilty;
        readonly IScraperService _scraperService;
        readonly IEventExporter _eventExporter;

        public EventFinder(
            IDocumentUtilty documentUtility,
            IScraperService scraperService,
            IEventExporter eventExporter,
            string document)
        {
            _scraperService = scraperService;
            _eventExporter = eventExporter;
            _documentUtilty = documentUtility;
            _documentUtilty.LoadDocument(document);
        }

        // Scrape the data
        public List<EventModel> GetEvents()
        {
            return _scraperService.GetEvents(_documentUtilty.Document);
        }

        // Scrape and Export the data
        public void ExportEventData()
        {
            var events = _scraperService.GetEvents(_documentUtilty.Document);
            _eventExporter.ExportEvents(events);
        }
    }
}
