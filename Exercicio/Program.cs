using Exercicio.Model;
using Exercicio.Repositories.Interfaces;
using Exercicio.Services;
using Exercicio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Exercicio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IJsonPersistenciaService<ClienteModel> _clienteJsonPersistenceService = new ClienteJsonPersistenciaService<ClienteModel>();
            //IJsonPersistenceService<VeiculoModel> _veiculoJsonPersistenceService = new VeiculoJsonPersistenceService <VeiculoModel>();
            //IJsonPersistenceService<ControleModel> _controleAcessoJsonPersistenceService = new ControleAcessoJsonPersistenceService<ControleModel>();
            //IJsonPersistenceService<ReceitaModel> _receitaJsonPersistenceService = new ReceitaJsonPersistenceService<ReceitaModel>();

            var _ = _clienteJsonPersistenceService.Recuperar() ?? Enumerable.Empty<dynamic>();
            var clientes = _.ToList();
            //var veiculo = _veiculoJsonPersistenceService.Recuperar();
            //var acessos = _controleAcessoJsonPersistenceService.Recuperar();
            //var clientes = _receitaJsonPersistenceService.Recuperar();

            var estacionados = new List<dynamic>();

            double preco = 0;
            double receitaTotal = 0;

            Console.WriteLine("==============================================================");
            Console.WriteLine("                  ESTACIONAMENTO GRUPO 3                      ");
            Console.WriteLine("==============================================================");

            Console.Write("Informe o valor inicial do estacionamento por minuto R$ ");
            preco = Double.Parse(Console.ReadLine());

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==============================================================");
                Console.WriteLine("           ESTACIONAMENTO GRUPO 3 - MENU DE OPÇÕES            ");
                Console.WriteLine("==============================================================");
                Console.WriteLine($"1 - Alterar Preço Atual (R$ {preco})");
                Console.WriteLine("2 - Cadastrar Cliente");
                Console.WriteLine("3 - Cadastrar Veículos de Clientes");
                Console.WriteLine("4 - Listar Clientes");
                Console.WriteLine("5 - Listar Veículos Estacionados");
                Console.WriteLine("6 - Cadastrar Entrada");
                Console.WriteLine("7 - Cadastrar Saída");
                Console.WriteLine("8 - Relatório de receita total");
                Console.WriteLine("9 - Sair");

                Console.Write("Digite uma das opções continuar: ");
                var opcao = Console.ReadLine();
                var sair = false;

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("=========Alteração de preço=======");

                        Console.Write("Digite o valor por minuto R$ ");
                        preco = Double.Parse(Console.ReadLine());
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("=========Cadastro de cliente=======");


                        //Console.Write("Informe o nome do cliente: ");
                        //string nome = Console.ReadLine();
                        //Console.Write("Informe o CPF do cliente: ");
                        //string cpf = Console.ReadLine();

                        // Testes
                        string nome = "Rafael";
                        string cpf = "55355455655";

                        dynamic cliente = new
                        {
                            Id = Guid.NewGuid().ToString(),
                            Nome = nome,
                            Cpf = cpf,
                            Veiculos = new List<dynamic>()
                        };

                        _clienteJsonPersistenceService.Salvar(cliente);

                        Console.WriteLine("Cliente cadastrado com sucesso!");
                        Thread.Sleep(1000);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("=========Cadastro de veículos=======");


                        Console.Write("Informe o CPF do cliente: ");
                        string cpfCliente = Console.ReadLine();

                        int encontrado = -1;
                        dynamic clienteEncontrado = null;

                        for (int i = 0; i < clientes.Count(); i++)
                        {
                            if (clientes[i].Cpf == cpfCliente)
                            {
                                encontrado = i;
                                clienteEncontrado = clientes[i];
                                break;
                            }
                        }
                        if (encontrado < 0)
                        {
                            Console.WriteLine("Erro! Cliente não encontrado ...");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            Console.Write("Informe a marca do veículo: ");
                            string marca = Console.ReadLine();
                            Console.Write("Informe o modelo do veículo: ");
                            string modelo = Console.ReadLine();
                            Console.Write("Informe a placa do veículo: ");
                            string placa = Console.ReadLine();

                            dynamic veiculo = new { 
                                Id = Guid.NewGuid(), 
                                Cliente_id = clienteEncontrado.Id, 
                                Marca = marca, 
                                Modelo = modelo, 
                                Placa = placa };

                            //JsonPersistenciaService.SalvarVeiculo(encontrado, veiculo);

                            Console.WriteLine("Veículo cadastrado com sucesso!");
                            Thread.Sleep(1000);
                        }
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("=========Lista de clientes=======");


                        foreach (var item in clientes)
                        {
                            Console.WriteLine($"Id: {item.Id}");
                            Console.WriteLine($"Nome: {item.Nome}");
                            Console.WriteLine($"CPF: {item.Cpf}");

                            Console.WriteLine("Veículos do cliente:");

                            foreach (var veiculo in item.Veiculos)
                            {
                                Console.WriteLine($"Id: {veiculo.Id} - Marca: {veiculo.Marca} - Modelo: {veiculo.Modelo} - Placa: {veiculo.Placa}");
                            }

                            Console.WriteLine("---------------------------------");
                        }

                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu ...");
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("=========Lista de veículos estacionados=======");


                        if(estacionados.Count == 0)
                            Console.WriteLine("O estacionamento está vazio!");

                        foreach (var item in estacionados)
                        {
                            foreach (var itemCliente in clientes)
                            {
                                foreach (var veiculo in itemCliente.Veiculos)
                                {
                                    if (item.Veiculo_id == veiculo.Id)
                                        Console.WriteLine($"Marca: {veiculo.Marca} - Modelo: {veiculo.Modelo} - Placa: {veiculo.Placa} - Entrada: {item.Entrada}");
                                }
                            }

                            Console.WriteLine("---------------------------------");
                        }

                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu ...");
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("=========Entrada de Veículo=======");


                        Console.Write("Informe a placa do veículo: ");
                        string placaVeiculo = Console.ReadLine();

                        dynamic veiculoEntrada = null;

                        foreach (var item in clientes)
                        {
                            for (int i = 0; i < item.Veiculos.Count; i++)
                            {
                                if (item.Veiculos[i].Placa == placaVeiculo)
                                {
                                    veiculoEntrada = item.Veiculos[i];
                                    break;
                                }
                            }
                            if (veiculoEntrada != null)
                                break;
                        }

                        if (veiculoEntrada == null)
                        {
                            Console.WriteLine("Erro! Veículo não encontrado, faça o cadastro do cliente/veículo ...");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            bool estaEstacionado = false;
                            for (int i = 0; i < estacionados.Count; i++)
                            {
                                if (estacionados[i].Veiculo_id == veiculoEntrada.Id)
                                {
                                    estaEstacionado = true;
                                    break;
                                }
                            }

                            if (estaEstacionado)
                            {
                                Console.WriteLine("Erro! Veículo já está estacionado ...");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Console.Write("Informe a data e hora (dd/MM/yyyy HH:mm) de entrada do veículo ou ENTER para usar data/hora atual: ");
                                
                                string dataInformada = Console.ReadLine();
                                DateTime dataHoraEntrada = DateTime.Now;
                                bool erro = false;

                                if (dataInformada != "")
                                {
                                    if (dataInformada.Length != 16)
                                    {
                                        erro = true;

                                        Console.WriteLine("Data/Hora informada é inválida!");
                                        Thread.Sleep(1000);
                                    }
                                    else
                                        dataHoraEntrada = DateTime.ParseExact(dataInformada, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                                }

                                if (!erro)
                                {
                                    dynamic estacionado = new { Id = new Guid(), Veiculo_id = veiculoEntrada.Id, Entrada = dataHoraEntrada, Saida = "" };
                                    estacionados.Add(estacionado);

                                    Console.WriteLine("Veículo estacionado com sucesso!");
                                    Thread.Sleep(1000);
                                }
                            }
                        }
                        break;

                    case "7":
                        Console.Clear();
                        Console.WriteLine("=========Saída de Veículo=======");


                        Console.Write("Informe a placa do veículo: ");
                        string placaVeiculoSaida = Console.ReadLine();

                        DateTime dataHoraEntradaVeiculo = DateTime.Now;
                        dynamic veiculoEncontrado = null;
                        dynamic veiculoEstacionado = null;
                        int posicaoVeiculoEstacionado = -1;

                        foreach (var item in clientes)
                        {
                            for (int i = 0; i < item.Veiculos.Count; i++)
                            {
                                if (item.Veiculos[i].Placa == placaVeiculoSaida)
                                {
                                    veiculoEncontrado = item.Veiculos[i];
                                    break;
                                }
                            }
                            if (veiculoEncontrado != null)
                                break;
                        }

                        for(int i = 0; i < estacionados.Count; i++)
                        {
                            if (estacionados[i].Veiculo_id == veiculoEncontrado.Id)
                            {
                                posicaoVeiculoEstacionado = i;
                                veiculoEstacionado = estacionados[i];
                            }
                        }

                        if (veiculoEstacionado == null)
                        {
                            Console.WriteLine("Erro! Veículo não está estacionado ...");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            Console.WriteLine($"Entrada do veículo: {dataHoraEntradaVeiculo}");
                            Console.Write("Informe a data e hora (dd/MM/yyyy HH:mm) de saída do veículo ou ENTER para usar data/hora atual: ");
                            string dataInformada = Console.ReadLine();

                            DateTime dataHoraSaida = DateTime.Now;
                            bool erro = false;

                            if (dataInformada != "")
                            {
                                if (dataInformada.Length != 16)
                                {
                                    erro = true;
                                    Console.WriteLine("Data/Hora informada é inválida!");
                                    Thread.Sleep(1000);
                                }
                                else
                                    dataHoraSaida = DateTime.ParseExact(dataInformada, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);                                
                            }

                            if (!erro)
                            {
                                dataHoraEntradaVeiculo = veiculoEstacionado.Entrada;
                                TimeSpan diferenca = dataHoraSaida.Subtract(dataHoraEntradaVeiculo);
                                TimeSpan diferencaSemSegundos = new TimeSpan(diferenca.Hours, diferenca.Minutes, 0);
                                double minutos = diferencaSemSegundos.TotalMinutes;

                                if (minutos == 0)
                                    minutos = 1; //Tempo mínimo

                                double totalTicket = minutos * preco;
                                string totalTicketString = string.Format("{0:N2}", totalTicket);
                                Console.WriteLine($"O valor total do período é de R$: {totalTicketString}.");

                                receitaTotal += totalTicket;

                                estacionados.RemoveAt(posicaoVeiculoEstacionado);

                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu ...");
                                Console.ReadKey();
                            }
                        }
                        break;

                    case "8":
                        Console.Clear();
                        Console.WriteLine("=========Relatório de Receita=======");


                        string totalReceitaString = string.Format("{0:N2}", receitaTotal);

                        Console.WriteLine($"O valor total acumulado no estacionamento foi de R$: {totalReceitaString}.");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu ...");
                        Console.ReadKey();
                        break;

                    case "9":
                        sair = true;
                        break;

                    default:
                        Console.WriteLine("Erro! Opção inválida ...");
                        Thread.Sleep(1000);
                        break;
                }

                if (sair)
                    break;
            }
        }
    }
}
