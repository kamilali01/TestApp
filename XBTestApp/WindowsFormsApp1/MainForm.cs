using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Loaders.Abstracts;
using WindowsFormsApp1.Loaders.Concretes;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Services;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string inputDirectory = textBoxPath.Text;
            TimeSpan monitoringFrequency = TimeSpan.FromSeconds((double)numericUpDownFrequency.Value);

            List<ILoader> loaders = new List<ILoader>
            {
                new CSVLoader(),
                new TXTLoader(),
                new XMLLoader()
            };

            DirectoryMonitor directoryMonitor = new DirectoryMonitor(inputDirectory, monitoringFrequency, loaders, DisplayTrades);

            Task.Run(() => directoryMonitor.StartMonitoring());
        }

        private void DisplayTrades(List<Trade> trades)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<Trade>>(DisplayTrades), trades);
                return;
            }

            listBoxTrades.Items.Clear();
            foreach (var trade in trades)
            {
                listBoxTrades.Items.Add(trade.ToString());
            }
        }
    }
}
