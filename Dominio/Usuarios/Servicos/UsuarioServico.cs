using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.Usuarios.Interfaces;

namespace Dominio.Usuarios.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuariosRepositorio usuariosRepositorio;
        public UsuarioServico(IUsuariosRepositorio usuariosRepositorio)
        {
            this.usuariosRepositorio = usuariosRepositorio;
        }

        public Usuario Editar(int id, string nome, string email, string senha)
        {
             Usuario usuario = Validar(id);

            if(usuario.Nome != nome) usuario.SetNome(nome);
            if(usuario.Email != email) usuario.SetEmail(email);
            if(usuario.Senha != senha) usuario.SetSenha(senha);
            
            return usuariosRepositorio.Editar(usuario);
            
        }

        public void Excluir(int id)
        {
            Usuario usuario = Validar(id);
            usuariosRepositorio.Excluir(usuario);

        }

        public Usuario Inserir(Usuario usuario)
        {
            var usuarioResponse = usuariosRepositorio.Inserir(usuario);
            return usuarioResponse;
        }

        public IQueryable<Usuario> Query()
        {
             var usuarioResponse = usuariosRepositorio.Query();
            return usuarioResponse;
        }

        public Usuario Recuperar(int id)
        {
           var usuarioResponse = usuariosRepositorio.Recuperar(id);
            return usuarioResponse;
        }

        public Usuario Validar(int id)
        {
           var usuarioResponse = usuariosRepositorio.Recuperar(id);
           if(usuarioResponse is null)
           {
            throw new Exception("Usuario não encontrado");
           }
           return usuarioResponse;
        }
    }
}