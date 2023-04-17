using Exercicio.Model;
using Exercicio.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            var lista = JsonPersistenciaRepository.Lista("clientes.json");

            lista.Add(cliente);
            JsonPersistenciaRepository.Salvar("clientes.json", lista);
        }

        public static void SalvarVeiculo(int indice, dynamic veiculo)
        {
            var lista = JsonPersistenciaRepository.Lista("clientes.json");

            //List<VeiculoModel> listaVeiculos = new List<VeiculoModel> { veiculo };

            VeiculoModel veiculoNovo = new VeiculoModel()
            {
                Id = veiculo.Id.ToString(),
                Cliente_id = veiculo.Cliente_id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Placa = veiculo.Placa
            };

            //ClienteModel clienteNovo = new ClienteModel()
            //{
            //    Id = lista[indice].Id.ToString(),
            //    Cpf = lista[indice].Cpf,
            //    Nome = lista[indice].Nome,
            //    Veiculos = lista[indice].Veiculos
            //};

            lista[indice].Veiculos.Add(veiculoNovo);

            JsonPersistenciaRepository.Salvar("clientes.json", lista);
        }

        public static List<ClienteModel> Lista()
        {            
            return JsonPersistenciaRepository.Lista("clientes.json");
        }
    }
}
