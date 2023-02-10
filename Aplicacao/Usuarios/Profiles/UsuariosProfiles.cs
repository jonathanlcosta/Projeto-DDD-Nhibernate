using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataTransfer.Request;
using DataTransfer.Usuarios.Requests;
using DataTransfer.Usuarios.Responses;
using Dominio.Entidades;

namespace Aplicacao.Usuarios.Profiles
{
    public class UsuariosProfiles : Profile
    {
        
        public UsuariosProfiles()
        {
            CreateMap<UsuarioInserirRequest, Usuario>();
            CreateMap<UsuarioEditarRequest, Usuario>();
            CreateMap<Usuario, UsuarioInserirResponse>();
            CreateMap<Usuario, UsuarioResponse>();
        }
    }
}