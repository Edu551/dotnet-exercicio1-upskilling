using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.Repositories.Interfaces
{
    internal interface IJsonPersistenciaRepository<T>
    {
        IEnumerable<T> Recuperar();
        T Recuperar(string id);
        bool Salvar(List<T> models);
        bool Salvar(T model);
        bool Deletar(List<T> models);
        bool Deletar(T model);
        bool Atualizar(List<T> models);
        bool Atualizar(T model);
    }
}
