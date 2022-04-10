namespace Web.Servicios.Interfaces
{
    public interface INegocioService
    {
        public bool TengoPermisos(long id_negocio, long id_usuario);
        public bool SlugValido(long id_negocio, string slug);
    }
}
