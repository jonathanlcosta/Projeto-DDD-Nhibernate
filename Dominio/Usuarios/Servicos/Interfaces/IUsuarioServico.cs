using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Usuarios.Interfaces
{
    public interface IUsuarioServico
    {
        Usuario Recuperar(int id);

        Usuario Inserir(Usuario usuario);

        Usuario Editar(int id, string nome, string email, string senha);

        void Excluir(int id);

        IQueryable<Usuario> Query();

        Usuario Validar(int id);
    }
}