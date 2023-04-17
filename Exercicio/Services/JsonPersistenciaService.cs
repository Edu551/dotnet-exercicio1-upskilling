using Exercicio.Repository;
using Newtonsoft.Json;
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

            lista[indice].Veiculos.Add(veiculo);

            JsonPersistenciaRepository.Salvar("clientes.json", lista);
        }

        public static List<dynamic> Lista()
        {            
            return JsonPersistenciaRepository.Lista("clientes.json");
        }
    }
}
