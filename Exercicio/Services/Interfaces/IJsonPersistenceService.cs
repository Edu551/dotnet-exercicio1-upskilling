using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.Services.Interfaces
{
    internal interface IJsonPersistenciaService<T> where T : class
    {
        IEnumerable<dynamic> Recuperar();
        dynamic Recuperar(int id);
        bool Salvar(List<dynamic> models);
        bool Salvar(dynamic model);
        bool Deletar(List<dynamic> models);
        bool Deletar(dynamic model);
        bool Atualizar(List<dynamic> models);
        bool Atualizar(dynamic model);
    }
}
