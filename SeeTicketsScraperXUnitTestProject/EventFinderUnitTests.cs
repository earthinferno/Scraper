using HtmlAgilityPack;
using Moq;
using SeeTicketsScraper;
using SeeTicketsScraper.Models;
using SeeTicketsScraper.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SeeTicketsScraperXUnitTestProject
{
    public class EventFinderUnitTests
    {
        readonly Mock<IDocumentUtilty> mockDocumentUtility;
        readonly Mock<IScraperService> mockScraperService;
        readonly Mock<IDataExporter<EventModel>> mockEventExporter;
        readonly HtmlDocument _stubDocument;
        readonly List<EventModel> _stubEventsList;
        readonly Action<string> _stubHandler = (x) => { };

        readonly EventFinder _eventFinder;

        public EventFinderUnitTests()
        {
            mockDocumentUtility = new Mock<IDocumentUtilty>();
            mockScraperService = new Mock<IScraperService>();
            mockEventExporter = new Mock<IDataExporter<EventModel>>();
            

            _stubDocument = new HtmlDocument();
            mockDocumentUtility.Setup(x => x.Document).Returns(_stubDocument);

            _stubEventsList = new List<EventModel>();
            mockScraperService.Setup(x => x.GetEvents(_stubDocument)).Returns(_stubEventsList);

            mockEventExporter.Setup(x => x.ExportData(It.IsAny<List<EventModel>>(), It.IsAny<Action<string>>()));


            string document = "";
            _eventFinder = new EventFinder(mockDocumentUtility.Object, mockScraperService.Object, mockEventExporter.Object, _stubHandler, document);
        }


        [Fact]
        public void WhenIGetEvents_EventsExportIsPassedExpectedData()
        {
            _eventFinder.ExportEventData();

            mockEventExporter.Verify(x => x.ExportData(It.Is<List<EventModel>>(l => l == _stubEventsList), It.IsAny<Action<string>>()), Times.Once());
        }

        [Fact]
        public void WhenIGetEvents_EventsExportIsPassedCorrectHandler()
        {
            _eventFinder.ExportEventData();

            mockEventExporter.Verify(x => x.ExportData(It.IsAny<List<EventModel>>(), It.Is<Action<string>>(x => x == _stubHandler )), Times.Once());
        }
    }
}
