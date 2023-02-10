using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Genericos;

namespace Dominio.Interfaces
{
    public interface IUsuariosRepositorio : IGenericoRepositorio<Usuario>
    {
      Usuario Recuperar(int id);
      Usuario Inserir(Usuario usuario);
      Usuario Editar(Usuario usuario);
      void Excluir(int id);
      IQueryable<Usuario> Query();
 
    }
}