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
        public static void Salvar(dynamic argument)
        {
            var lista = JsonPersistenciaRepository.Lista("clientes.json");

            lista.Add(argument);
            JsonPersistenciaRepository.Salvar("clientes.json", lista);
        }

        public static List<dynamic> Lista()
        {            
            return JsonPersistenciaRepository.Lista("clientes.json");
        }
    }
}
