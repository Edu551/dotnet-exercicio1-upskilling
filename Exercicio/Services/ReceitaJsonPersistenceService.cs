using Exercicio.Model;
using Exercicio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercicio.Services
{
    public class ReceitaJsonPersistenceService<T> : IJsonPersistenciaRepository<T> where T : ClienteModel
    {
        public ReceitaJsonPersistenceService()
        {

        }

        public Task<bool> Atualizar(List<T> models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deletar(List<T> models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deletar(T model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Recuperar(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<T> Recuperar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Salvar(List<T> models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Salvar(T model)
        {
            throw new NotImplementedException();
        }
    }
}
