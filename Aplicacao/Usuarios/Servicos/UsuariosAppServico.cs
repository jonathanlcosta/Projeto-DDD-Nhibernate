using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Usuarios.Servicos.Interfaces;
using AutoMapper;
using DataTransfer.Request;
using DataTransfer.Usuarios.Requests;
using DataTransfer.Usuarios.Responses;
using Dominio.Entidades;
using Dominio.Usuarios.Interfaces;
using NHibernate;

namespace Aplicacao.Usuarios.Servicos
{
    public class UsuariosAppServico : IUsuariosAppServico
    {
        private readonly IMapper mapper;
        private readonly ISession session;
        private readonly IUsuarioServico usuarioServico;
        public UsuariosAppServico(IMapper mapper, ISession session, IUsuarioServico usuarioServico)
        {
            this.mapper = mapper;
            this.session = session;
            this.usuarioServico = usuarioServico;
        }

        public void Editar(UsuarioEditarRequest usuarioRequest)
        {
            usuarioRequest = usuarioRequest ?? new UsuarioEditarRequest();
            var usuarioEditar = mapper.Map<Usuario>(usuarioRequest);

            var transacao = session.BeginTransaction();

            try
            {
                usuarioServico.Editar(
                    usuarioEditar.Id,
                    usuarioEditar.Nome,
                    usuarioEditar.Email,
                    usuarioEditar.Senha
                
                );
            }
            catch (Exception e)
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                throw e;
            }
        }

        public void Excluir(int id)
        { 
            Usuario usuario = usuarioServico.Recuperar(id);
           ITransaction transaction = session.BeginTransaction();
           try
           {
            usuarioServico.Excluir(id);
            transaction.Commit();
           }
           catch
           {
            transaction.Rollback();
           }
        }

        public UsuarioInserirResponse Inserir(UsuarioInserirRequest usuarioRequest)
        {
            usuarioRequest = usuarioRequest ?? new UsuarioInserirRequest();

            Usuario usuarioInserir = mapper.Map<Usuario>(usuarioRequest);

            ITransaction transacao = session.BeginTransaction();

            try
            {
                usuarioInserir = usuarioServico.Inserir(usuarioInserir);
                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<UsuarioInserirResponse>(usuarioInserir);
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                return null;
            }
            
        }

        public UsuarioResponse Recuperar(int id)
        {
            try
            {
                Usuario usuarioValidado = usuarioServico.Validar(id);
                return mapper.Map<UsuarioResponse>(usuarioValidado);
            }
            catch
            {
                return null;
            }
        }

        public IList<Usuario> RecuperarUsuarios()
        {
            IList<Usuario> usuarios = usuarioServico.Query().ToList();
            return usuarios;
        }
    }
}