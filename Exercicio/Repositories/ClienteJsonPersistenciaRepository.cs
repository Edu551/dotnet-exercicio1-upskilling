using Exercicio.Model;
using Exercicio.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Exercicio.Repository
{
    public class ClienteJsonPersistenciaRepository<T> : IJsonPersistenciaRepository<T> where T : ClienteModel
    {
        private const string FILE_NAME = "ClientesJsonContext.json";
        private static string _contextPath;

        public ClienteJsonPersistenciaRepository(string nomeRepositorio = FILE_NAME)
        {
            _contextPath = CriarRepositorio(nomeRepositorio);
        }

        private string CriarRepositorio(string nomeRepositorio)
        {
            string caminhoRaiz = Directory.GetCurrentDirectory();

            bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows);
            string separador = isWindows ? "\\" : "/";

            string caminhoArquivo = caminhoRaiz + separador + nomeRepositorio + ".json";

            if (File.Exists(caminhoArquivo))
                return caminhoArquivo;

            using (File.Create(caminhoArquivo)) { }

            return caminhoArquivo;
        }

        public bool Salvar(List<T> models)
        {
            try
            {
                models.ForEach(argument =>
                {
                    File.WriteAllText(_contextPath, JsonConvert.SerializeObject(models));
                });

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Salvar(T model)
        {
            string stringJson = JsonConvert.SerializeObject(model);

            try
            {
                File.WriteAllText(_contextPath, stringJson);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerable<T> Recuperar()
        {
            string clientesJson = File.ReadAllText(_contextPath);
            return JsonConvert.DeserializeObject<List<T>>(clientesJson);
        }

        public T Recuperar(string id)
        {
            string clientesJson = File.ReadAllText(_contextPath);
            List<T> clientes = JsonConvert.DeserializeObject<List<T>>(clientesJson);

            return clientes.Find(cliente => cliente.Id == id);
        }

        public bool Atualizar(List<T> models)
        {
            List<T> novosRegistros = new List<T>();

            string clientesJson = File.ReadAllText(_contextPath);
            var clientes = JsonConvert.DeserializeObject<List<T>>(clientesJson);

            clientes.ForEach(cliente =>
            {
                if (models.FindAll(model => model.Id == cliente.Id).Any())
                {
                    novosRegistros.Add(models.Single(model => model.Id == cliente.Id));
                }
                else
                {
                    novosRegistros.Add(cliente);
                }
            });

            try
            {
                File.WriteAllText(_contextPath, JsonConvert.SerializeObject(novosRegistros));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Atualizar(T model)
        {
            List<T> novosRegistros = new List<T>();

            string clientesJson = File.ReadAllText(_contextPath);
            var clientes = JsonConvert.DeserializeObject<List<T>>(clientesJson);

            clientes.ForEach(cliente =>
            {
                if (model.Id == cliente.Id)
                {
                    novosRegistros.Add(model);
                }
                else
                {
                    novosRegistros.Add(cliente);
                }
            });

            try
            {
                File.WriteAllText(_contextPath, JsonConvert.SerializeObject(novosRegistros));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Deletar(List<T> models)
        {
            List<T> novosRegistros = new List<T>();

            string clientesJson = File.ReadAllText(_contextPath);
            var clientes = JsonConvert.DeserializeObject<List<T>>(clientesJson);

            clientes.ForEach(cliente =>
            {
                if (!models.FindAll(model => model.Id == cliente.Id).Any())
                {
                    novosRegistros.Add(cliente);
                }

            });

            try
            {
                File.WriteAllText(_contextPath, JsonConvert.SerializeObject(novosRegistros));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Deletar(T model)
        {
            List<T> novosRegistros = new List<T>();

            string clientesJson = File.ReadAllText(_contextPath);
            var clientes = JsonConvert.DeserializeObject<List<T>>(clientesJson);

            clientes.ForEach(cliente =>
            {
                if (model.Id != cliente.Id)
                {
                    novosRegistros.Add(cliente);
                }
            });

            try
            {
                File.WriteAllText(_contextPath, JsonConvert.SerializeObject(novosRegistros));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
