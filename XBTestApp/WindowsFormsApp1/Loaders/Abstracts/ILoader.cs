using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Loaders.Abstracts
{
    public interface ILoader
    {
        List<Trade> Load(string filePath);
    }
}
