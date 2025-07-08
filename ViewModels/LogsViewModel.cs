using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;

namespace ExamenProgreso3_JulianTorres.ViewModels
{
    public partial class LogsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> logs = new();

        public LogsViewModel()
        {
            CargarLogs();
        }

        public void CargarLogs()
        {
            string logPath = Path.Combine(FileSystem.AppDataDirectory, "Logs_Torres.txt");
            if (File.Exists(logPath))
            {
                var lineas = File.ReadAllLines(logPath);
                Logs = new ObservableCollection<string>(lineas);
            }
        }
    }
}
