using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoUsuarios.Models
{
    public class User
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string CURP { get; set; }
        public string EdoCivil { get; set; }
        public string Genero { get; set; }
        public string ImgSRC { get; set; }
        public string Alternative { get; set; }
    }
}