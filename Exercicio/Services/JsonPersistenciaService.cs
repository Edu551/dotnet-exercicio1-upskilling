using Exercicio.Model;
using Exercicio.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.Services
{
    public class JsonPersistenciaService
    {
        public static void Salvar(dynamic cliente)
        {
            var lista = JsonPersistenciaRepository.Lista<ClienteModel>("clientes.json");

            var listaVeiculo = new List<VeiculoModel>();

            foreach (var veiculo in cliente.Veiculos)
            {
                VeiculoModel veiculoNovo = new VeiculoModel()
                {
                    Id = veiculo.Id.ToString(),
                    Cliente_id = veiculo.Cliente_id,
                    Marca = veiculo.Marca,
                    Modelo = veiculo.Modelo,
                    Placa = veiculo.Placa
                };
                listaVeiculo.Add(veiculoNovo);
            }

            ClienteModel clienteNovo = new ClienteModel()
            {
                Id = cliente.Id.ToString(),
                Cpf = cliente.Cpf,
                Nome = cliente.Nome,
                Veiculos = listaVeiculo
            };

            lista.Add(clienteNovo);
            JsonPersistenciaRepository.Salvar("clientes.json", lista);
        }

        public static void SalvarVeiculo(int indice, dynamic veiculo)
        {
            var lista = JsonPersistenciaRepository.Lista<ClienteModel>("clientes.json");

            VeiculoModel veiculoNovo = new VeiculoModel()
            {
                Id = veiculo.Id.ToString(),
                Cliente_id = veiculo.Cliente_id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Placa = veiculo.Placa
            };

            lista[indice].Veiculos.Add(veiculoNovo);

            JsonPersistenciaRepository.Salvar("clientes.json", lista);
        }

        public static void SalvarEstacionado(dynamic estacionado)
        {
            var lista = JsonPersistenciaRepository.Lista<EstacionadoModel>("estacionados.json");

            EstacionadoModel estacionadoNovo = new EstacionadoModel()
            {
                Id = estacionado.Id.ToString(),
                Veiculo_id = estacionado.Veiculo_id,
                Entrada = DateTime.Now,
                Saida = (estacionado.Saida != "") ? estacionado.Saida : null
            };

            lista.Add(estacionadoNovo);

            JsonPersistenciaRepository.Salvar("estacionados.json", lista);
    }

        public static List<T> Lista<T>(string arquivo) where T : class
        {
            return JsonPersistenciaRepository.Lista<T>(arquivo);
        }
    }
}
