using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System.Collections.ObjectModel;
using ExamenProgreso3_JulianTorres.Models;
using System.IO;

namespace ExamenProgreso3_JulianTorres.ViewModels
{
    public partial class ListaClientesViewModel : ObservableObject
    {
        private SQLiteAsyncConnection _db;

        [ObservableProperty]
        private ObservableCollection<Cliente> clientes = new();

        public ListaClientesViewModel()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "clientes.db");
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Cliente>();
            _ = CargarClientesAsync();
        }

        public async Task CargarClientesAsync()
        {
            var lista = await _db.Table<Cliente>().ToListAsync();
            Clientes = new ObservableCollection<Cliente>(lista);
        }
    }
}
