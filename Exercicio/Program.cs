using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercicio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clientes = new List<dynamic>();
            var estacionados = new List<dynamic>();
            double preco = new double();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Digite uma das opções abaixo:");
                Console.WriteLine("1 - Configurar Preço");
                Console.WriteLine("2 - Cadastrar Cliente");
                Console.WriteLine("3 - Cadastrar Veículos de Clientes");
                Console.WriteLine("4 - Listar Clientes");
                Console.WriteLine("5 - Listar Veículos Estacionados");
                Console.WriteLine("6 - Cadastrar Entrada");
                Console.WriteLine("7 - Cadastrar Saída");
                Console.WriteLine("9 - Sair");

                var opcao = Console.ReadLine();
                var sair = false;

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Digite o valor por minuto R$ ");
                        preco = Double.Parse(Console.ReadLine());
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Informe o nome do cliente: ");
                        string nome = Console.ReadLine();
                        Console.Write("Informe o CPF do cliente: ");
                        string cpf = Console.ReadLine();
                        dynamic cliente = new { Id = Guid.NewGuid(), Nome = nome, Cpf = cpf, Veiculos = new List<dynamic>() };
                        clientes.Add(cliente);
                        Console.WriteLine("Cliente cadastrado com sucesso!");
                        Thread.Sleep(1000);
                        break;
                    case "3":
                        Console.Write("Informe o CPF do cliente: ");
                        string cpfCliente = Console.ReadLine();
                        int encontrado = -1;
                        for(int i = 0; i < clientes.Count(); i++)
                        {
                            if (clientes[i].Cpf == cpfCliente)
                            {
                                encontrado = i;
                                break;
                            }
                        }
                        if(encontrado < 0)
                        {
                            Console.WriteLine("Cliente não encontrado ...");
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
                            dynamic veiculo = new { Id = Guid.NewGuid(), Cliente_id = clientes[encontrado].Id, Marca = marca, Modelo = modelo, Placa = placa };
                            clientes[encontrado].Veiculos.Add(veiculo);
                            Console.WriteLine("Veículo cadastrado com sucesso!");
                            Thread.Sleep(1000);
                        }

                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("=========Lista de clientes=======");
                        foreach(var item in clientes)
                        {
                            Console.WriteLine($"Id: {item.Id}");
                            Console.WriteLine($"Nome: {item.Nome}");
                            Console.WriteLine($"CPF: {item.Cpf}");
                            Console.WriteLine("----Veículos do cliente----");
                            foreach(var veiculo in item.Veiculos)
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
                        foreach (var item in estacionados)
                        {
                            foreach (var itemCliente in clientes)
                            {
                                foreach (var veiculo in itemCliente.Veiculos)
                                {
                                    if (item.Veiculo_id == veiculo.Id)
                                    {
                                        Console.WriteLine($"Marca: {veiculo.Marca} - Modelo: {veiculo.Modelo} - Placa: {veiculo.Placa} - Entrada: {item.Entrada}");
                                    }
                                }
                            }
                            Console.WriteLine("---------------------------------");
                        }
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu ...");
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.WriteLine("=========Entrada de Veículo=======");
                        Console.Write("Informe a placa do veículo: ");
                        string placaVeiculo = Console.ReadLine();
                        int encontrou = -1;
                        Guid? veiculoId = null;
                        foreach(var item in clientes)
                        {
                            for(int i = 0; i < item.Veiculos.Count; i++)
                            {
                                if (item.Veiculos[i].Placa == placaVeiculo)
                                {
                                    veiculoId = item.Veiculos[i].Id;
                                    encontrou = i;
                                    break;
                                }
                            }
                            if(encontrou >= 0)
                            {
                                break;
                            }
                        }
                        if(encontrou < 0)
                        {
                            Console.WriteLine("Veículo não encontrado, faça o cadastro do cliente/veículo ...");
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
                                {
                                    dataHoraEntrada = DateTime.ParseExact(dataInformada, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                                }
                            }
                            if (!erro)
                            {
                                dynamic estacionado = new { Id = new Guid(), Veiculo_id = veiculoId, Entrada = dataHoraEntrada, Saida = "" };
                                estacionados.Add(estacionado);
                                Console.WriteLine("Veículo estacionado com sucesso!");
                                Thread.Sleep(1000);
                            }
                        }
                        break;
                    case "7":
                        Console.WriteLine("=========Saída de Veículo=======");
                        Console.Write("Informe a placa do veículo: ");
                        string placaVeiculoSaida = Console.ReadLine();
                        int encontrouVeiculoDeCliente = -1;
                        int encontrouEstacionado = -1;
                        Guid? veiculoIdEntrada = null;
                        DateTime dataHoraEntradaVeiculo = DateTime.Now;
                        dynamic veiculoEncontrado = null;
                        dynamic veiculoEstacionado = null;
                        foreach (var item in clientes)
                        {
                            for (int i = 0; i < item.Veiculos.Count; i++)
                            {
                                if (item.Veiculos[i].Placa == placaVeiculoSaida)
                                {
                                    veiculoIdEntrada = item.Veiculos[i].Id;
                                    encontrouVeiculoDeCliente = i;
                                    veiculoEncontrado = item.Veiculos[i];
                                    break;
                                }
                            }
                            if (encontrouVeiculoDeCliente >= 0)
                            {
                                break;
                            }
                        }

                        foreach(var item in estacionados)
                        {
                            if(item.Veiculo_id == veiculoEncontrado.Id)
                            {
                                veiculoEstacionado = item;
                            }
                        }
                        
                        if (veiculoEstacionado == null)
                        {
                            Console.WriteLine("Veículo não está estacionado ...");
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
                                {
                                    dataHoraSaida = DateTime.ParseExact(dataInformada, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                                }
                            }
                            if (!erro)
                            {
                                dataHoraEntradaVeiculo = veiculoEstacionado.Entrada;
                                TimeSpan diferenca = dataHoraSaida.Subtract(dataHoraEntradaVeiculo);
                                TimeSpan diferencaSemSegundos = new TimeSpan(diferenca.Hours, diferenca.Minutes, 0);
                                double minutos = diferencaSemSegundos.TotalMinutes;
                                double totalTicket = minutos * preco;
                                string totalTicketString = string.Format("{0:N2}", totalTicket);
                                Console.WriteLine($"O valor total do período é de R$: {totalTicketString}.");

                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu ...");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case "9":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida ...");
                        Thread.Sleep(1000);
                        break;
                }

                if (sair) break;
            }


        }
    }
}
