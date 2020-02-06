using System;
using System.Collections.Generic;
using SeeTicketsScraper.Models;
using SeeTicketsScraper.Services;

namespace SeeTicketsScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventFinder = new EventFinder(
                new HtmlUtility(), 
                new SeeTicketsScraperService(), 
                new JsonDataExporter<EventModel>(),
                (x) => { Console.WriteLine(x); },
                "https://www.seetickets.com/search?BrowseOrder=Relevance&q=&s=&se=false&c=3&dst=&dend=&l"
            );

            eventFinder.ExportEventData();
        }
    }
}
