using System;
using System.Collections.Generic;
using System.Text;

namespace SeeTicketsScraper.Models
{
    public class EventModel
    {
        public string EventName { get; set; }
        public string Venue { get; set; }
        public string Date { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
    }
}
