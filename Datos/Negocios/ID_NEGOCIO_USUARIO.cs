using Entidades.Negocios;
using Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Usuarios {
    public class ID_NEGOCIO_USUARIO : IEntityTypeConfiguration<NEGOCIOUSUARIO> {
        public void Configure(EntityTypeBuilder<NEGOCIOUSUARIO> builder) {
            builder.ToTable("NegocioUsuario")
                .HasKey(x => x.IdNegocioUsuario);
        }
    }
}
