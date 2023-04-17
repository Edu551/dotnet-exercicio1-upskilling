using Exercicio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.Services
{
    public class JsonPersistenciaService
    {
        public static void Salvar(dynamic veiculo)
        {
            var lista = JsonPersistenciaRepository.Lista("clientes.json");

            lista.Add(veiculo);
            JsonPersistenciaRepository.Salvar("clientes.json", lista);

            Console.WriteLine("Veiculo cadastrado");
            Console.ReadKey();
        }
    }
}
