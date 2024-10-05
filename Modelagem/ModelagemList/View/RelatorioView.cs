using System;
using System.Collections.Generic;
using Model;
using Controller;
using ModelagemList.Data;
using System.Linq;
using System.Runtime.InteropServices;

namespace ModelagemList.View
{
    public class RelatorioView
    {
        private ClientController clientController;

        public RelatorioView()
        {
            clientController = new ClientController(); // Certifique-se de inicializar o clientController
            this.Init();
        }

        public void Init()
        {
            int option = 0;
           do{
            Console.WriteLine("************************");
            Console.WriteLine("Você está em Relatórios.");
            Console.WriteLine("************************");
            Console.WriteLine("");
            Console.WriteLine("1 - Intervalo Médio entre chegadas.");
            Console.WriteLine("2 - Duração Média dos atendimentos.");
            Console.WriteLine("3 - Tabela de Funcionamento.");
            Console.WriteLine("4 - Tamanho da Fila.");
            Console.WriteLine("5 - Tempo Médio de Espera na Fila.");
            Console.WriteLine("0 - SAIR");
            Console.WriteLine("");

            
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número.");
            }

            switch (option)
            {
                case 1:
                    Console.WriteLine(intervalo());
                    break;

                case 2:
                    Console.WriteLine(Duração());
                    break;

                case 3:
                    Console.WriteLine(Funcionamento());
                    break;

                case 4:
                    Console.WriteLine(TamanhoFila());
                    break;

                case 5:
                    Console.WriteLine(Espera());
                    break;

                default:
                    Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                    break;
            }
           }while (option > 0);
        }

        public string intervalo()
        {
            

            List<Client> listagem = clientController.List();
            int somaCheg = 0;

            if (listagem.Count <= 0)
            {
                return "Insira algum cliente para ser calculado!!";
            }

            for (int i = 0; i < listagem.Count; i++)
            {
                somaCheg += Int32.Parse(listagem[i].MomChegada); 
            }

            int cheg = somaCheg / listagem.Count;

            return "Intervalo Médio entre Chegadas: " + cheg;
        }

        public string Duração()
        {
            

            List<Client> listagem = clientController.List();
            int somaDura = 0;

            if (listagem.Count <= 0)
            {
                return "Insira algum cliente para ser calculado!!";
            }

            for (int i = 0; i < listagem.Count; i++)
            {
                somaDura += Int32.Parse(listagem[i].DurAtendimento); 
            }

            int Dura = somaDura / listagem.Count;

            return "Intervalo Médio entre Chegadas: " + Dura;
        }

        public string Funcionamento()
        {
            

            List<Client> listagem = clientController.List();
           
            if (listagem.Count <= 0)
            {
                return "Insira algum cliente para ser calculado!!";
            }

            for (int i = 0; i < listagem.Count; i++)
            {
                Console.WriteLine(Print(listagem[i]));
            }

            return "";
            
        }

        public string TamanhoFila()
        {
            

            List<Client> listagem = clientController.List();
           
            if (listagem.Count <= 0)
            {
                return "Insira algum cliente para ser calculado!!";
            }
            return "Tamanho da Fila: " + listagem.Count;
            
        }
        public string Espera()
        {
            List<Client> listagem = clientController.List();

            if (listagem.Count <= 0)
            {
                return "Insira algum cliente para ser calculado!!";
            }

            int totalEspera = 0;

            for (int i = 0; i < listagem.Count - 1; i++)
            {
                int tempoSaidaAtual = Int32.Parse(listagem[i].MomChegada) + Int32.Parse(listagem[i].DurAtendimento);
                int tempoChegadaProximo = Int32.Parse(listagem[i + 1].MomChegada);

                if (tempoChegadaProximo < tempoSaidaAtual)
                {
                    listagem[i + 1].TempoEspera = tempoSaidaAtual - tempoChegadaProximo;
                    listagem[i + 1].MomChegada = tempoSaidaAtual.ToString();
                }
                else
                {
                    listagem[i + 1].TempoEspera = 0;
                }

                totalEspera += listagem[i + 1].TempoEspera;
            }

            return "Total de tempo de espera dos clientes: " + totalEspera;
        }




        private string Print(Client client)
        {
            string retorno = "";
            retorno += $"Cliente: {client.Id}\n";
            retorno += $"Tempo Chegada: {client.MomChegada}\n";
            retorno += $"Duração: {client.DurAtendimento}\n";
            retorno += "-------------------------------------------\n";

            return retorno;
        }
    }
}
