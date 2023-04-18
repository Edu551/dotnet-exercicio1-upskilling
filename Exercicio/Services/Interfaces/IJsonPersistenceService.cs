using System.Collections.Generic;

namespace Exercicio.Services.Interfaces
{
    internal interface IJsonPersistenciaService<T> where T : class
    {
        IEnumerable<dynamic> Recuperar();
        dynamic Recuperar(string id);
        bool Salvar(List<dynamic> models);
        bool Salvar(dynamic model);
        bool Deletar(List<dynamic> models);
        bool Deletar(dynamic model);
        bool Atualizar(List<dynamic> models);
        bool Atualizar(dynamic model);
    }
}
