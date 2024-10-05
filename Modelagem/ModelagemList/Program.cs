using ModelagemList.View;
using View;


int option = 0;

do
{
    Console.WriteLine("************************");
    Console.WriteLine("Menu Modelagem de Listas");
    Console.WriteLine("************************");
    Console.WriteLine("");
    Console.WriteLine("1 - Clientes");
    Console.WriteLine("2 - Relatórios");
    Console.WriteLine("0 - SAIR");
    
    option = Convert.ToInt32(Console.ReadLine());

    switch(option)
    {
        case 1 :
            Console.WriteLine("Opção Clientes");
            ClientView clientView = new ClientView();
        break;

        case 2 :
            Console.WriteLine("Opção Clientes");
            RelatorioView relatorioView = new RelatorioView();
        break;

        default :
        break;
    }

    static void MenuRep()
    {
        Console.WriteLine("************************");
        Console.WriteLine("Você está em Relatórios.");
        Console.WriteLine("************************");
        Console.WriteLine("");
        Console.WriteLine("1 - Intervalo Médio entre chegadas. ");
        Console.WriteLine("2 - Duração Média dos atendimentos. ");
        Console.WriteLine("3 - Tabela de Funcionamento. ");
        Console.WriteLine("4 - Tamanho da Fila. ");
        Console.WriteLine("5 - Tempo Médio de Espera na Fila. ");
        Console.WriteLine("0 - SAIR");
        Console.WriteLine("");

        int option = 0;

        option = Convert.ToInt32(Console.ReadLine());
            
        switch(option)
        {
            case 1 :
                Console.WriteLine("Intervalo Médio entre chegadas.../n");
                
            break;
               
            case 2 :
                Console.WriteLine("Duração Média dos atendimentos.../n");
            break;

            case 3 :
                Console.WriteLine("Tabela de Funcionamento.../n");
            break;

            case 4 :
                Console.WriteLine("Tamanho da Fila.../n");
            break;

            case 5 :
                Console.WriteLine("Tempo Médio de Espera na Fila.../n");
            break;

            default:
            break;
        }
            
    }


}
while(option > 0);