namespace Web.Models.Servicio.PUT
{
    public class ServicioParams
    {
        public long idevento { get; set; }
        public long idservicio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public double precio_en_puerta { get; set; }
        public bool visibilidad { get; set; }
        public int cantidad { get; set; }
        public string fecha_inicio_venta { get; set; }
        public string fecha_fin_venta { get; set; }
        public long idestadoservicio { get; set; }
        public int cantidad_max_pp { get; set; }
    }
}
