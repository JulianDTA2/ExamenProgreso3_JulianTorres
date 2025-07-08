using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLite;
using System.IO;
using System.Windows.Input;
using ExamenProgreso3_JulianTorres.Models;

namespace ExamenProgreso3_JulianTorres.ViewModels
{
    public partial class ClienteViewModel : ObservableObject
    {
        private SQLiteAsyncConnection _db;

        public ClienteViewModel()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "clientes.db");
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Cliente>();
        }

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string empresa;

        [ObservableProperty]
        private int antiguedadMeses;

        [ObservableProperty]
        private bool activo;

        [RelayCommand]
        public async Task GuardarClienteAsync()
        {
            if (AntiguedadMeses * 10 > 1500)
            {
                await Shell.Current.DisplayAlert("Error", "No se puede registrar una empresa con más de 1500 días de antigüedad.", "OK");
                return;
            }

            var nuevoCliente = new Cliente
            {
                Nombre = Nombre,
                Empresa = Empresa,
                AntiguedadMeses = AntiguedadMeses,
                Activo = Activo
            };

            await _db.InsertAsync(nuevoCliente);

            string logPath = Path.Combine(FileSystem.AppDataDirectory, "Logs_Torres.txt");
            string mensaje = $"Se incluyó el registro [{Nombre}] el {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            File.AppendAllText(logPath, mensaje);

            Nombre = string.Empty;
            Empresa = string.Empty;
            AntiguedadMeses = 0;
            Activo = false;

            await Shell.Current.DisplayAlert("Éxito", "Cliente guardado correctamente", "OK");
        }
    }
}
