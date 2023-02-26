using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Usuario : BaseEntity
    {
        public virtual string? Nome { get; protected set; }
        public virtual string? Email { get; protected set; }
        public virtual string? Senha { get; protected set; }
        public Usuario(){}
        public Usuario(string nome, string email, string senha)
        {
            SetNome(nome);
            SetEmail(email);
            SetSenha(senha);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
        {
            throw new Exception("O nome é obrigatório.");
        }
        this.Nome = nome;
        }

        public virtual void SetEmail(string email)
        {
            try
        {
            var addr = new System.Net.Mail.MailAddress(email);
        }
        catch
        {
            throw new Exception("Endereço de e-mail inválido.");
        }
        this.Email = email;
        }

        public virtual void SetSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
        {
            throw new Exception("A senha é obrigatória.");
        }

        if (senha.Length < 8)
        {
            throw new Exception("A senha deve ter pelo menos 8 caracteres.");
        }

        if (!senha.Any(char.IsDigit))
        {
            throw new Exception("A senha deve conter pelo menos um número.");
        }

        if (!senha.Any(char.IsUpper))
        {
            throw new Exception("A senha deve conter pelo menos uma letra maiúscula.");
        }
        this.Senha = senha;
                }

        
    }
}