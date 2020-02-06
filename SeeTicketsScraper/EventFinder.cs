using SeeTicketsScraper.Services;
using SeeTicketsScraper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeTicketsScraper
{
    // I would not normally anotate with comments but in this context I will
    // The intention behind this class is to be a composite object with it's specific behaviour injected 
    // into the constructor. It is using Dependancy Inversion as it knows not what library objects it will
    // be using just there abstracted behaviour.
    // I was unsure where to delegate the responsibility to what to export the data too (console,file,streem, etc) 
    // but I decided that would be handled by the exporter. The exporter itself could be injected with the actual 
    // for this specific concern.
    public class EventFinder
    {
        readonly IDocumentUtilty _documentUtilty;
        readonly IScraperService _scraperService;
        readonly IDataExporter<EventModel> _eventExporter;

        public EventFinder(
            IDocumentUtilty documentUtility,
            IScraperService scraperService,
            IDataExporter<EventModel> eventExporter,
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
            _eventExporter.ExportData(events);
        }
    }
}
