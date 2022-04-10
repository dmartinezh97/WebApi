using Entidades.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Usuarios {
    public class ID_USUARIO : IEntityTypeConfiguration<USUARIOS> {
        public void Configure(EntityTypeBuilder<USUARIOS> builder) {
            builder.ToTable("USUARIOS")
                .HasKey(x => x.ID_USUARIO);
        }
    }
}
