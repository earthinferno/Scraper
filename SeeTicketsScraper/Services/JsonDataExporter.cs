using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SeeTicketsScraper.Services
{
    // I would not normally anotate with comments but in this context I will
    // The intention is to be able to provide a specfic implementation for 
    // exporting behaviour. in this case for JSON

    public class JsonDataExporter<T> : IDataExporter<T>
    {
        public void ExportData(List<T> data)
        {
            // This is tightly coupled but we could inject an object implementing
            // an IOutputEnvironmentInterface type interface
            Console.WriteLine(JsonConvert.SerializeObject(data));
        }
    }
}
