using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Genericos
{
    public interface IGenericoRepositorio<T>
    {
        T Recuperar(int id);

        T Inserir(T entidade);

        T Editar(T entidade);

        void Excluir(int id);

        IQueryable<T> Query();
    }
}