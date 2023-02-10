using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.Usuarios.Interfaces;
using Dominio.Usuarios.Servicos;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Dominio.Testes.Usuarios.Servicos
{
    public class UsuarioServicoTestes
    {
       private readonly IUsuarioServico sut;
       private readonly Usuario usuarioValido;
       private readonly IUsuariosRepositorio usuariosRepositorio;
       public UsuarioServicoTestes()
       {
        usuarioValido = Builder<Usuario>.CreateNew().Build();
        usuariosRepositorio = Substitute.For<IUsuariosRepositorio>();
        sut = new UsuarioServico(usuariosRepositorio);
       }
        public class ValidarMetodo: UsuarioServicoTestes
        {
            [Fact]
            public void Quando_UsuarioNaoEncontrado_Espero_Excecao()
            {
                usuariosRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);
                sut.Invoking(x => x.Validar(3)).Should().Throw<Exception>();
            }

            [Fact]
            public void Quando_UsuarioEncontrado_Espero_UsuarioValido()
            {
                usuariosRepositorio.Recuperar(Arg.Any<int>()).Returns(x => usuarioValido);
                sut.Validar(1);
                Usuario usuarioRetorno = sut.Validar(1);
                usuarioRetorno.Should().BeSameAs(usuarioValido);
            }
        }

        public class InserirUsuario: UsuarioServicoTestes
        {
            [Fact]
            public void Quando_ParametrosParaCriarUsuarioForemValidos_Espero_UsuarioValido()
            {
                usuariosRepositorio.Inserir(Arg.Any<Usuario>()).Returns(x => usuarioValido);
                Usuario usuarioRetorno = sut.Inserir(usuarioValido);
                usuarioRetorno.Should().BeSameAs(usuarioValido);
            }
        }

        public class AtualizarUsuario: UsuarioServicoTestes
        {
            [Fact]
            public void Quando_ParametrosParaAtualizarUsuarioForemValidos_Espero_UsuarioValido()
            {
                usuariosRepositorio.Editar(Arg.Any<Usuario>()).Returns(x => usuarioValido);
                Usuario usuarioRetorno = sut.Editar(usuarioValido.Id,usuarioValido.Nome,usuarioValido.Email, usuarioValido.Senha);
                usuarioRetorno.Should().BeSameAs(usuarioValido);
            }
        }

        public class ListarUsuario: UsuarioServicoTestes
        {
             [Fact]
        public void Quando_UsuariosEstiveremListados_Espero_ListaDeUsuario()
        {
            var listaUsuarios = new[]
            {
                new Usuario { Id = 1, Nome = "Usuario 1" },
                new Usuario { Id = 2, Nome = "Usuario 2" },
            };
            usuariosRepositorio.Query().Returns(listaUsuarios.AsQueryable());
            var actualUsuarios = sut.Query();
            actualUsuarios.Should().BeEquivalentTo(listaUsuarios);
        }
        }

        public class ExcluirUsuario : UsuarioServicoTestes
        {
        [Fact]
        public void Quando_PrecisoExcluirUsuarios_Espero_UsuarioExcluido()
        {
            var usuarioId = 1;
            sut.Excluir(usuarioId);
            usuariosRepositorio.Received(1).Excluir(usuarioId);
        }
        }
    }
}