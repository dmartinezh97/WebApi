using Entidades.Eventos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Servicios
{
    public class SERVICIOS
    {
        public long ID_SERVICIO { get; set; }
        public long ID_EVENTO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public double PRECIO { get; set; }
        public double PRECIO_EN_PUERTA { get; set; }
        public bool VISIBILIDAD { get; set; }
        public int CANTIDAD { get; set; }
        public DateTime FECHA_INICIO_VENTA { get; set; }
        public DateTime FECHA_FIN_VENTA { get; set; }
        public int CANTIDAD_MAX_PP { get; set; }
        public long ID_ESTADO_SERVICIO { get; set; }
        
        
        [ForeignKey("ID_EVENTO")]
        public EVENTOS EVENTOS { get; set; }
    }
}
