using Entidades.Negocios;
using Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Usuarios {
    public class ID_NEGOCIO_USUARIO : IEntityTypeConfiguration<NEGOCIO_USUARIO> {
        public void Configure(EntityTypeBuilder<NEGOCIO_USUARIO> builder) {
            builder.ToTable("NEGOCIO_USUARIO")
                .HasKey(x => x.ID_NEGOCIO_USUARIO);
        }
    }
}
