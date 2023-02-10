using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using FluentNHibernate.Mapping;

namespace Infra.Mapeamentos
{
    public class UsuariosMap: ClassMap<Usuario>
    {
        public UsuariosMap()
        {
            Schema("Site");
            Table("usuario");
            Id(x => x.Id).Column("id");
            Map(x => x.Nome).Column("nome");
            Map(x => x.Senha).Column("senha");
            Map(x => x.Email).Column("email");
            Map(x => x.CriadoEm).Column("criadoEm");
            Map(x => x.AtualizadoEm).Column("atualizadoEm");
        }
    }
}