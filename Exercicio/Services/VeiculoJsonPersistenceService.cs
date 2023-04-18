using Exercicio.Model;
using Exercicio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercicio.Services
{
    public class VeiculoJsonPersistenceService<T> : IJsonPersistenciaService<T> where T : ClienteModel
    {
        public VeiculoJsonPersistenceService()
        {

        }

        public bool Atualizar(List<dynamic> models)
        {
            throw new NotImplementedException();
        }

        public bool Atualizar(dynamic model)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(List<dynamic> models)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(dynamic model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> Recuperar()
        {
            throw new NotImplementedException();
        }

        public dynamic Recuperar(string id)
        {
            throw new NotImplementedException();
        }

        public bool Salvar(List<dynamic> models)
        {
            throw new NotImplementedException();
        }

        public bool Salvar(dynamic model)
        {
            throw new NotImplementedException();
        }
    }
}
