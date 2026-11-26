using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Eletrodomestico> lista = new List<Eletrodomestico>();

    static void Cadastrar()
    {
        Eletrodomestico eletrodomestico = new Eletrodomestico();

        Console.Write("Nome: ");
        eletrodomestico.Nome = Console.ReadLine();

        Console.Write("Potência em kW: ");
        eletrodomestico.Potencia = double.Parse(Console.ReadLine());

        Console.Write("Horas de uso por dia: ");
        eletrodomestico.Horas = double.Parse(Console.ReadLine());

        lista.Add(eletrodomestico);

        Console.WriteLine("Eletrodoméstico cadastrado!");
    }

    static void Listar()
    {
        foreach (Eletrodomestico eletrodomestico in lista)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Nome: " + eletrodomestico.Nome);
            Console.WriteLine("Potência: " + eletrodomestico.Potencia);
            Console.WriteLine("Horas por dia: " + eletrodomestico.Horas);
        }
    }

    static void Salvar()
    {
        StreamWriter arquivo = new StreamWriter("eletrodomesticos.txt");

        foreach (Eletrodomestico eletrodomestico in lista)
        {
            arquivo.WriteLine(eletrodomestico.Nome + "|" +
                eletrodomestico.Potencia + "|" + eletrodomestico.Horas);
        }

        arquivo.Close();

        Console.WriteLine("Dados salvos!");
    }

    static void Carregar()
    {
        if (File.Exists("eletrodomesticos.txt"))
        {
            lista.Clear();

            string[] linhas = File.ReadAllLines("eletrodomesticos.txt");

            foreach (string linha in linhas)
            {
                string[] dados = linha.Split('|');

                Eletrodomestico eletrodomestico = new Eletrodomestico();

                eletrodomestico.Nome = dados[0];
                eletrodomestico.Potencia = double.Parse(dados[1]);
                eletrodomestico.Horas = double.Parse(dados[2]);

                lista.Add(eletrodomestico);
            }

            Console.WriteLine("Dados carregados!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado!");
        }
    }

    static void BuscarNome()
    {
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine();

        foreach (Eletrodomestico eletrodomestico in lista)
        {
            if (eletrodomestico.Nome.ToLower() == nome.ToLower())
            {
                Console.WriteLine("Nome: " + eletrodomestico.Nome);
                Console.WriteLine("Potência: " + eletrodomestico.Potencia);
                Console.WriteLine("Horas: " + eletrodomestico.Horas);
            }
        }
    }

    static void BuscarConsumo()
    {
        Console.Write("Digite o consumo mínimo: ");
        double valor = double.Parse(Console.ReadLine());

        foreach (Eletrodomestico eletrodomestico in lista)
        {
            double consumo = eletrodomestico.Potencia * eletrodomestico.Horas;

            if (consumo > valor)
            {
                Console.WriteLine(eletrodomestico.Nome);
                Console.WriteLine("Consumo diário: " + consumo + " kWh");
            }
        }
    }

    static void CalcularConsumo()
    {
        double totalDia = 0;

        foreach (Eletrodomestico eletrodomestico in lista)
        {
            totalDia += eletrodomestico.Potencia * eletrodomestico.Horas;
        }

        double totalMes = totalDia * 30;

        Console.Write("Valor do kWh em reais: ");
        double preco = double.Parse(Console.ReadLine());

        Console.WriteLine("Consumo diário: " + totalDia + " kWh");
        Console.WriteLine("Consumo mensal: " + totalMes + " kWh");

        Console.WriteLine("Valor diário: R$ " + (totalDia * preco));
        Console.WriteLine("Valor mensal: R$ " + (totalMes * preco));
    }

    static void Main(string[] args)
    {
        int opcao = 0;

        while (opcao != 7)
        {
            Console.WriteLine("\n--- MENU ELETRODOMÉSTICOS ---");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Listar");
            Console.WriteLine("3 - Salvar");
            Console.WriteLine("4 - Carregar");
            Console.WriteLine("5 - Buscar por nome");
            Console.WriteLine("6 - Buscar por consumo");
            Console.WriteLine("7 - Sair");
            Console.WriteLine("8 - Calcular consumo");
            Console.Write("Opção: ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Cadastrar();
                    break;
                case 2:
                    Listar();
                    break;
                case 3:
                    Salvar();
                    break;
                case 4:
                    Carregar();
                    break;
                case 5:
                    BuscarNome();
                    break;
                case 6:
                    BuscarConsumo();
                    break;
                case 8:
                    CalcularConsumo();
                    break;
            }
        }
    }
}
