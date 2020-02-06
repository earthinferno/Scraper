using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeTicketsScraper
{
    public interface IDocumentUtilty
    {
        public void LoadDocument(string document);
        public HtmlDocument Document { get; }
    }
}
