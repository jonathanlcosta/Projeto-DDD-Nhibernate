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
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using ISession = NHibernate.ISession;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
         private readonly IUsuariosAppServico usuariosAppServico;
        public UsuariosController(IUsuariosAppServico usuariosAppServico)
        {
            this.usuariosAppServico = usuariosAppServico;
        }

        [HttpGet]
        public ActionResult<IList<UsuarioResponse>> RecuperarUsuarios()
        {
           var response = usuariosAppServico.RecuperarUsuarios();
            return Ok(response) ;
        }
        [HttpPost]
        public ActionResult<UsuarioInserirResponse> InserirUsuario([FromBody]UsuarioInserirRequest usuarioRequest)
        {
           var retorno = usuariosAppServico.Inserir(usuarioRequest);
            return Ok(retorno);
            
         }
        [HttpPut("{id}")]
        public ActionResult Editar(int id, [FromBody] UsuarioEditarRequest usuarioRequest){
          usuarioRequest.Id = id;
           usuariosAppServico.Editar(usuarioRequest);
            return Ok();
           
        }
        [HttpDelete("{id}")]
        public void DeletarUsuario(int id)
        {
        usuariosAppServico.Excluir(id);
        }
        [HttpGet("{id}")]
        public ActionResult<UsuarioResponse> RecuperarUsuario(int id)
        {
            UsuarioResponse response = usuariosAppServico.Recuperar(id);
            return Ok(response);      }
    }
}