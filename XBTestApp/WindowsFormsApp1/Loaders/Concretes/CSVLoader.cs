using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WindowsFormsApp1.Loaders.Abstracts;
using System.Globalization;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Loaders.Concretes
{
    public class CSVLoader:ILoader
    {
        public List<Trade> Load(string filePath)
        {
            List<Trade> trades = new List<Trade>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var columns = line.Split(',');
                var trade = new Trade
                {
                    Date = DateTime.Parse(columns[0], CultureInfo.InvariantCulture),
                    Open = decimal.Parse(columns[1], CultureInfo.InvariantCulture),
                    High = decimal.Parse(columns[2], CultureInfo.InvariantCulture),
                    Low = decimal.Parse(columns[3], CultureInfo.InvariantCulture),
                    Close = decimal.Parse(columns[4], CultureInfo.InvariantCulture),
                    Volume = long.Parse(columns[5], CultureInfo.InvariantCulture)
                };
                trades.Add(trade);
            }

            return trades;
        }
    }
}
