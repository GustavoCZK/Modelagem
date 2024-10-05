using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model;
using Controller;
using System.Runtime.InteropServices;

namespace View
{
    public class ClientView
    {
        private ClientController clientController;

        public ClientView()
        {
            clientController = new ClientController();
            this.Init();
        }
        public void Init()
        {
            int option = 0;
            
           do{
            Console.WriteLine("**********************");
            Console.WriteLine("Você está em Clientes.");
            Console.WriteLine("**********************");
            Console.WriteLine("");
            Console.WriteLine("1 - Inserir Clientes");
            Console.WriteLine("2 - Listar Clientes");
            Console.WriteLine("0 - Voltar");
            Console.WriteLine("");

            

            option = Convert.ToInt32(Console.ReadLine());
            
            switch(option)
            {
                case 1 :
                    Insert();
                break;
                case 2 :
                    List();
                break;

                default:
                break;
            }
           } while(option > 0);
        }

        private void Insert()
        {
            Client client = new Client();
            client.Id = clientController.GetNextId();

            Console.WriteLine("\nInforme O Momento de chegada: ");
            client.MomChegada = Console.ReadLine();

            Console.WriteLine("\nInforme Tempo de Atendimento: ");
            client.DurAtendimento = Console.ReadLine();


            

            bool retorno = clientController.Insert(client);

            if(retorno == true)
            {
                Console.WriteLine("Cliente inserido com sucesso!");
            }
            else
                Console.WriteLine("Falha ao inserir, verifique os dados!");
        }

        private void List()
        {
            List<Client> listagem = clientController.List();
            //Controlador + Acumulador + Flag
            for(int i = 0; i < listagem.Count; i++)
            {
                Console.WriteLine(Print(listagem[i]));
            }
        }

        private string Print(Client client)
        {
            string retorno = "";
            retorno += $"Cliente: {client.Id}\n";
            retorno += $"Tempo Chegada: {client.MomChegada} \n";
            retorno += $"Duração: {client.DurAtendimento} \n";
            retorno += "------------------------------------------- \n";

            return retorno;
        }

    }
}