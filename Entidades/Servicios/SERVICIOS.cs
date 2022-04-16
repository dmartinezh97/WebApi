using Entidades.Eventos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Servicios
{
    public class SERVICIOS
    {
        public long IdServicio { get; set; }
        public long IdEvento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double PrecioEnPuerta { get; set; }
        public bool Visibilidad { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaInicioVenta { get; set; }
        public DateTime FechaFinVenta { get; set; }
        public int CantidadMaximaPorPersona { get; set; }
        public string EstadoServicio { get; set; }
        
        
        [ForeignKey("ID_EVENTO")]
        public EVENTOS EVENTOS { get; set; }
    }
}
