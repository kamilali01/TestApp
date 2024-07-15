using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using WindowsFormsApp1.Loaders.Abstracts;
using WindowsFormsApp1.Loaders.Concretes;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Services
{
    public class DirectoryMonitor
    {
        private string _inputDirectory;
        private TimeSpan _monitoringFrequency;
        private List<ILoader> _loaders;
        private FileSystemWatcher _watcher;
        private Dictionary<string, ILoader> _extensionToLoaderMap;
        private Action<List<Trade>> _onNewTrades;

        public DirectoryMonitor(string inputDirectory, TimeSpan monitoringFrequency, List<ILoader> loaders, Action<List<Trade>> onNewTrades)
        {
            _inputDirectory = inputDirectory;
            _monitoringFrequency = monitoringFrequency;
            _loaders = loaders;
            _onNewTrades = onNewTrades;

            _extensionToLoaderMap = new Dictionary<string, ILoader>
        {
            { ".csv", _loaders.OfType<CSVLoader>().FirstOrDefault() },
            { ".txt", _loaders.OfType<TXTLoader>().FirstOrDefault() },
            { ".xml", _loaders.OfType<XMLLoader>().FirstOrDefault() }
        };

            _watcher = new FileSystemWatcher(_inputDirectory)
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
            };
            _watcher.Created += OnNewFileDetected;
            _watcher.EnableRaisingEvents = true;
        }

        public void StartMonitoring()
        {
            while (true)
            {
                Thread.Sleep(_monitoringFrequency);
                CheckForNewFiles();
            }
        }

        private void CheckForNewFiles()
        {
            var files = Directory.GetFiles(_inputDirectory);
            foreach (var file in files)
            {
                ProcessFile(file);
            }
        }

        private void OnNewFileDetected(object sender, FileSystemEventArgs e)
        {
            ProcessFile(e.FullPath);
        }

        private void ProcessFile(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();
            if (_extensionToLoaderMap.ContainsKey(extension))
            {
                var loader = _extensionToLoaderMap[extension];
                var trades = loader.Load(filePath);
                _onNewTrades?.Invoke(trades);
            }
        }
    }
}
