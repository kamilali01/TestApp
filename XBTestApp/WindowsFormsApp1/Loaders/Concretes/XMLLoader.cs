using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WindowsFormsApp1.Loaders.Abstracts;
using System.Globalization;
using System.Xml.Linq;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Loaders.Concretes
{
    public class XMLLoader:ILoader
    {
        public List<Trade> Load(string filePath)
        {
            List<Trade> trades = new List<Trade>();
            var doc = XDocument.Load(filePath);

            foreach (var element in doc.Descendants("value"))
            {
                var trade = new Trade
                {
                    Date = DateTime.Parse(element.Attribute("date").Value, CultureInfo.InvariantCulture),
                    Open = decimal.Parse(element.Attribute("open").Value, CultureInfo.InvariantCulture),
                    High = decimal.Parse(element.Attribute("high").Value, CultureInfo.InvariantCulture),
                    Low = decimal.Parse(element.Attribute("low").Value, CultureInfo.InvariantCulture),
                    Close = decimal.Parse(element.Attribute("close").Value, CultureInfo.InvariantCulture),
                    Volume = long.Parse(element.Attribute("volume").Value, CultureInfo.InvariantCulture)
                };
                trades.Add(trade);
            }

            return trades;
        }
    }
}
