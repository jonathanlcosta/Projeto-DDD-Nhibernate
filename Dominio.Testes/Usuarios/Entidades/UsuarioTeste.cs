using Dominio.Entidades;
using FizzWare.NBuilder;
using FluentAssertions;
using Xunit;


namespace Dominio.Testes.Usuarios
{
    public class UsuarioTeste
    {
        private readonly Usuario sut; 
        public UsuarioTeste()
        {
            sut = Builder<Usuario>.CreateNew().Build();
        }

        public class SetNomeMetodo: UsuarioTeste
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("                ")]
            public void Dado_NomeNuloOuEspacoEmBranco_Espero_Excecao(string nome)
            {
                sut.Invoking(x => x.SetNome(nome)).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_NomeValido_Espero_PropriedadesPreenchidas()
            {
                string nome = "Silvio";
                sut.SetNome(nome);
                sut.Nome.Should().NotBeNullOrWhiteSpace(nome);
                sut.Nome.Should().Be(nome);
            }
        }

        public class SetEmail : UsuarioTeste
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("                ")]
            public void Dado_EmailNuloOuEspacoEmBranco_Espero_Excecao(string email)
            {
                sut.Invoking(x => x.SetNome(email)).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_EmailValido_Espero_PropriedadesPreenchidas()
            {
                string email = "jonathan@gmail.com.br";
                sut.SetEmail(email);
                sut.Email.Should().NotBeNullOrWhiteSpace();
                sut.Email.Should().Be(email);
                sut.Email.Should().Match("*@*.com.br");
            }


        }

        public class Construtor
        {
            [Fact]
            public void Quando_Parametros_ForemValidos_Espero_ObjetoIntegro()
            {
                var usuario = new Usuario("Gabriela", "Gabriela@gmail.com", "Gabriela123");
                usuario.Nome.Should().Be("Gabriela");
                usuario.Email.Should().Be("Gabriela@gmail.com");
                usuario.Senha.Should().Be("Gabriela123");
                
            }

        }

        public class SetSenhaMetodo : UsuarioTeste 
        {
            [Theory]
            [InlineData(null)]
            [InlineData("   ")]
            [InlineData("")]
            [InlineData("1234")]
            [InlineData("senhatesteparaver")]
            public void Dado_SenhaInvalida_Espero_Excecao(string senha)
            {
                 sut.Invoking(x => x.SetSenha(senha)).Should().Throw<Exception>();
            }
            [Fact]
            public void Dado_SenhaValida_Espero_CamposPreenchidos_Corretamente()
            {
                string senha = "Senha@123456";
                sut.SetSenha(senha);
                sut.Senha.Should().NotBeNullOrWhiteSpace();
                sut.Senha.Should().Be(senha);
                sut.Senha.Should().NotBeLowerCased();
                sut.Senha.Should().NotBeUpperCased();
            }
        }


    }
}