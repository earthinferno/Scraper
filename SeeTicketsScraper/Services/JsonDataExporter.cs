using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SeeTicketsScraper.Services
{
    // I would not normally anotate with comments but in this context I will
    // The intention is to be able to provide a specfic implementation for 
    // exporting behaviour. in this case for JSON
    // Notice I have made it highly poloymorphic allowing for generic data types
    // and passing in a delgate to handle the where/what to output to
    public class JsonDataExporter<T> : IDataExporter<T>
    {
        public void ExportData(List<T> data, Action<string> output)
        {
            output(JsonConvert.SerializeObject(data));
        }
    }
}
