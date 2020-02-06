using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeTicketsScraper
{
    public class HtmlUtility: IDocumentUtilty
    {
        public HtmlDocument Document { get; private set; }

        public void LoadDocument(string document)
        {
            if (Document == null)
            {
                HtmlWeb htmlDoc = new HtmlWeb();
                Document = htmlDoc.Load(document);
            }
        }
    }
}
