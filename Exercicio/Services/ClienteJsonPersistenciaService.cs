using Exercicio.Model;
using Exercicio.Repositories.Interfaces;
using Exercicio.Repository;
using Exercicio.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio.Services
{
    public class ClienteJsonPersistenciaService<T> : IJsonPersistenciaService<T> where T : ClienteModel
    {
        readonly IJsonPersistenciaRepository<T> _clienteJsonPersistenciaRepository;

        public ClienteJsonPersistenciaService()
        {
            _clienteJsonPersistenciaRepository = new ClienteJsonPersistenciaRepository<T>();
        }

        public bool Atualizar(List<dynamic> models)
        {
            List<T> clientesModel = new List<T>();

            models.ForEach(model =>
            {
                ClienteModel clienteModel = new ClienteModel()
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    Veiculos = model.Veiculos
                };
            });

            return _clienteJsonPersistenciaRepository.Atualizar(clientesModel);
        }

        public bool Atualizar(dynamic model)
        {
            ClienteModel clienteModel = new ClienteModel()
            {
                Id = model.Id,
                Nome = model.Nome,
                Cpf = model.Cpf,
                Veiculos = model.Veiculos
            };

            return _clienteJsonPersistenciaRepository.Atualizar(clienteModel as T);
        }

        public bool Deletar(List<dynamic> models)
        {
            List<ClienteModel> clientesModel = new List<ClienteModel>();

            models.ForEach(model =>
            {
                ClienteModel clienteModel = new ClienteModel()
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    Veiculos = model.Veiculos
                };
            });

            return _clienteJsonPersistenciaRepository.Deletar(clientesModel as T);
        }

        public bool Deletar(dynamic model)
        {
            ClienteModel clienteModel = new ClienteModel()
            {
                Id = model.Id,
                Nome = model.Nome,
                Cpf = model.Cpf,
                Veiculos = model.Veiculos
            };

            return _clienteJsonPersistenciaRepository.Deletar(clienteModel as T );
        }

        public IEnumerable<dynamic> Recuperar()
        {
            return _clienteJsonPersistenciaRepository.Recuperar();
        }

        public dynamic Recuperar(string id)
        {
            return _clienteJsonPersistenciaRepository.Recuperar(id);
        }

        public bool Salvar(List<dynamic> models)
        {
            List<ClienteModel> clientesModel = new List<ClienteModel>();

            models.ForEach(model =>
            {
                ClienteModel clienteModel = new ClienteModel()
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    Veiculos = model.Veiculos
                };
            });

            return _clienteJsonPersistenciaRepository.Salvar(clientesModel as T);
        }

        public bool Salvar(dynamic model)
        {
            ClienteModel clienteModel = new ClienteModel()
            {
                Id = model.Id,
                Nome = model.Nome,
                Cpf = model.Cpf,
                Veiculos = model.Veiculos as List<VeiculoModel>
            };

            return _clienteJsonPersistenciaRepository.Salvar(clienteModel as T);
        }
    }
}
