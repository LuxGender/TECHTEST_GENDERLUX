using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//modelo que contiene nuestros constructores

namespace Back_datosUs.Models
{//metodos
    public class DatosUsuario
    {
    public int IdUsuario{ get; set; }
    public String Nombre { get; set; }
    public String Correo { get; set; }
    public String Departamento { get; set; }

        public DatosUsuario() {}

        //cambio a minuscula de nombre/ constructores
        public DatosUsuario(int id, String nombre, String correo, String depto)
        {
            //quitar this. a las variables si no funciona
            this.IdUsuario = id;
            this.Nombre = nombre;
            this.Correo = correo;
            this.Departamento = depto;
        }

        public DatosUsuario(String nombre, String correo, String depto)
        {
            //agrear thi. a las variavles si no funciona
            this.Nombre = nombre;
            this.Correo = correo;
            this.Departamento = depto;
        }
    }
}