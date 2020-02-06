using SeeTicketsScraper.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SeeTicketsScraperXUnitTestProject
{
    public class SetTicketsScraperService
    {
        IScraperService scraperService = new SeeTicketsScraperService();
        public SetTicketsScraperService()
        {

        }

        [Fact]
        public void WhenIGetEvents_EventsAreReturnedAsExpected()
        {


        }

    }
}
