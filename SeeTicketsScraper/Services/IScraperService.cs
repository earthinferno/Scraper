using HtmlAgilityPack;
using System.Collections.Generic;
using SeeTicketsScraper.Models;

namespace SeeTicketsScraper.Services
{
    public interface IScraperService
    {
        public List<EventModel> GetEvents(HtmlDocument htmlDoc);
    }
}
