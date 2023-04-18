using Exercicio.Context;
using Exercicio.Model;
using Exercicio.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Exercicio.Repository
{
    public class ClienteJsonPersistenciaRepository<T> : IJsonPersistenciaRepository<T> where T : ClienteModel
    {
        readonly string _pathBase = JsonContext.RecuperarCaminhoBase()["clientesBase"];

        public bool Atualizar(List<T> models)
        {
            throw new NotImplementedException();
        }

        public bool Atualizar(T model)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(List<T> models)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(T model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Recuperar()
        {
            throw new NotImplementedException();
        }

        public T Recuperar(string id)
        {
            throw new NotImplementedException();
        }

        public bool Salvar(List<T> models)
        {
            throw new NotImplementedException();
        }

        public bool Salvar(T model)
        {
            try
            {
                var obj = new
                {
                    Cpf = model.Cpf,
                    Data = new
                    {
                        Id = model.Id,
                        Nome = model.Nome,
                        Veiculos = model.Veiculos,
                    }
                };

                string json = JsonConvert.SerializeObject(obj);

                File.WriteAllText(_pathBase, json, Encoding.UTF8);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
