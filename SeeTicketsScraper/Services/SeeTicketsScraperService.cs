using HtmlAgilityPack;
using SeeTicketsScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace SeeTicketsScraper.Services
{
    // I would not normally anotate with comments but in this context I will
    // The code in here is terrible, buggy and not extendible.
    // I planned to refactor this to greatness but....
    // The articles on the SeeTickets page contain html that is not XHTML compliant so only
    // event name was easy to get at. I've used a mixture on Linq extension methods and Agility
    // pack methods but not much XPath.
    // For the actual searching of nodes it would have been nice to pass in delagates with the actual
    // business logic (knowledge of html structure) but I would need to spend some time sorting out 
    // the code first before i could get to refactor this.
    // I thought it would be better to focus on the client class 'Event Finder' to demonstrate some
    // software engineering principles.
    public class SeeTicketsScraperService : IScraperService
    {
      
        public List<EventModel> GetEvents(HtmlDocument htmlDoc)
        {
            var eventItems = new List<EventModel>();
            foreach (var node in GetHtmlNodes(htmlDoc, "//article[@class='result-text']"))
            {
                eventItems.Add(GetEventDetails(node));
            }
            return eventItems;
        }

        public static IEnumerable<HtmlNode> GetHtmlNodes(HtmlDocument navigableDoc, string Xpath)
        {
            return navigableDoc.DocumentNode.SelectNodes(Xpath);
        }


        public EventModel GetEventDetails(HtmlNode node)
        {
            return new EventModel
            {
                EventName = GetEventName(node),
                Venue = FormatString(GetVenueName(node)),
                Date = FormatString(GetDate(node)),
                ImageUrl = GetImageLocation(node),
                Status = { }
            };
        }


        public string GetEventName(HtmlNode node)
        {
            return node.Descendants().Where(n => n.GetAttributeValue("class", "").Equals("event-title")).Single().InnerText;
        }


        public string GetVenueName(HtmlNode node)
        {
            ////This code is awful
            try
            {
                var subText = node
                .Descendants()
                .Where(n => n.GetAttributeValue("class", "")
                .Equals("g-blocklist-sub-text "))
                .First()
                .Descendants()
                .ToList();

                return GetNodeByPos(subText, 5);

            }
            catch
            {
                return "";
            }
        }


        public string GetDate(HtmlNode node)
        {
            ////This code is awful
            try
            {
                var subText = node
                .Descendants()
                .Where(n => n.GetAttributeValue("class", "")
                .Equals("g-blocklist-sub-text "))
                .First()
                .Descendants()
                .ToList();

                return GetNodeByPos(subText, 8);

            }
            catch
            {
                return "";
            }
        }

        public static string GetImageLocation(HtmlNode node)
        {
            ////This code is awful.
            try
            {
                return node
                .Descendants()
                .Where(n => n.GetAttributeValue("class", "")
                .Equals("g-blocklist-main"))
                .First()
                .SelectSingleNode("//img")
                .GetAttributeValue("src", "");
            }
            catch
            {
                return "";
            }
        }

        public static string GetNodeByPos(List<HtmlNode> nodes, int pos)
        {
            ////This code is awful
            if (nodes.Count >= pos)
            {
                return FormatString(nodes.ElementAt(pos).InnerText); 
            }
            return "";
        }




        public static string FormatString(string s)
        {
            s = Regex.Replace(s, @"\s+", " ");
            return s;
        }

    }
}
