using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeeTicketsScraper
{
    // I would not normally anotate with comments but in this context I will
    // A wrapper to make the specific library code injectable.
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
