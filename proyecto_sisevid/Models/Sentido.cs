﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Sentido
    {
        int id;
        string nombre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Sentido(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        public Sentido()
        {
            this.id = 0;
            this.nombre = "";
        }
    }
}