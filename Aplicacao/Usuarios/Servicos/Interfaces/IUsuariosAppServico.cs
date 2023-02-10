using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransfer.Request;
using DataTransfer.Usuarios.Requests;
using DataTransfer.Usuarios.Responses;
using Dominio.Entidades;

namespace Aplicacao.Usuarios.Servicos.Interfaces
{
    public interface IUsuariosAppServico
    {
        UsuarioResponse Recuperar(int id);
        UsuarioInserirResponse Inserir(UsuarioInserirRequest usuarioRequest);
        void Editar(UsuarioEditarRequest usuarioEditarRequest);
        void Excluir(int id);
        IList<Usuario> RecuperarUsuarios();

    }
}