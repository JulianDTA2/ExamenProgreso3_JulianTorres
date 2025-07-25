﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgreso3_JulianTorres.Models
{
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public int AntiguedadMeses { get; set; }
        
        [Ignore]
        public int AntiguedadDias => AntiguedadMeses * 10;
        public bool Activo { get; set; }
    }
}
