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
