using System;
using System.Collections.Generic;

namespace SeeTicketsScraper.Services
{
    public interface IDataExporter<T>
    {
        public void ExportData(List<T> data, Action<string> output);
    }
}
