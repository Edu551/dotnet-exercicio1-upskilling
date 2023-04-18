using Exercicio.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Exercicio.Context
{
    public static class JsonContext
    {
        private static string _contextPathClientes = CriarArquivoContexto("clientes", "json");
        private static string _contextPathVeiculos = CriarArquivoContexto("veiculos", "json");
        private static string _contextPathAcessos = CriarArquivoContexto("acessos", "json");
        private static string _contextPathReceita = CriarArquivoContexto("receita", "json");

        public static IEnumerable<ClienteModel> Clientes { get => CarregarClientes(); }
        public static IEnumerable<VeiculoModel> Veiculos { get => CarregarVeiculos(); }
        public static IEnumerable<ControleAcessosModel> Acessos { get => CarregarAcessos(); }
        public static IEnumerable<ReceitaModel> Receita { get => CarregarReceita(); }

        public static void CarregarBases()
        {
            CarregarClientes();
            CarregarVeiculos();
            CarregarAcessos();
            CarregarReceita();
        }

        public static Dictionary<string, string> RecuperarCaminhoBase()
        {
            return new Dictionary<string, string>()
            {
                { "clientesBase", _contextPathClientes },
                { "veiculosBase", _contextPathVeiculos },
                { "acessosBase", _contextPathAcessos },
                { "receitaBase", _contextPathReceita },
            };
        }

        private static IEnumerable<ClienteModel> CarregarClientes()
        {
            string json = File.ReadAllText(_contextPathClientes);
            List<ClienteModel> clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(json);
            return clientes.AsEnumerable() ?? Enumerable.Empty<ClienteModel>();
        }

        private static IEnumerable<VeiculoModel> CarregarVeiculos()
        {
            string json = File.ReadAllText(_contextPathVeiculos);
            List<VeiculoModel> veiculos = JsonConvert.DeserializeObject<List<VeiculoModel>>(json);
            return veiculos.AsEnumerable() ?? Enumerable.Empty<VeiculoModel>();
        }

        private static IEnumerable<ControleAcessosModel> CarregarAcessos()
        {
            string json = File.ReadAllText(_contextPathAcessos);
            List<ControleAcessosModel> acessos = JsonConvert.DeserializeObject<List<ControleAcessosModel>>(json);
            return acessos.AsEnumerable() ?? Enumerable.Empty<ControleAcessosModel>();
        }

        private static IEnumerable<ReceitaModel> CarregarReceita()
        {
            string json = File.ReadAllText(_contextPathReceita);
            List<ReceitaModel> receitas = JsonConvert.DeserializeObject<List<ReceitaModel>>(json);
            return receitas.AsEnumerable() ?? Enumerable.Empty<ReceitaModel>(); ;
        }

        private static string CriarArquivoContexto(string contextName, string type)
        {
            string caminhoRaiz = Directory.GetCurrentDirectory();

            bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows);
            string separador = isWindows ? "\\" : "/";

            string caminhoArquivo = $"{caminhoRaiz}{separador}{contextName}.{type}";

            if (File.Exists(caminhoArquivo))
                return caminhoArquivo;

            using (File.Create(caminhoArquivo)) { }

            return caminhoArquivo;
        }
    }
}

