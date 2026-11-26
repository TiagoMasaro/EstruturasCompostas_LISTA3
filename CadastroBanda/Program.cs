using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Banda> listaBanda = new List<Banda>();

    static void Cadastrar()
    {
        Banda banda = new Banda();

        Console.Write("Nome da banda: ");
        banda.Nome = Console.ReadLine();

        Console.Write("Gênero musical: ");
        banda.Genero = Console.ReadLine();

        Console.Write("Número de integrantes: ");
        banda.Integrantes = int.Parse(Console.ReadLine());

        Console.Write("Posição no ranking: ");
        banda.Ranking = int.Parse(Console.ReadLine());

        listaBanda.Add(banda);

        Console.WriteLine("Banda cadastrada!");
    }

    static void Listar()
    {
        foreach (Banda banda in listaBanda)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Nome: " + banda.Nome);
            Console.WriteLine("Gênero: " + banda.Genero);
            Console.WriteLine("Integrantes: " + banda.Integrantes);
            Console.WriteLine("Ranking: " + banda.Ranking);
        }
    }

    static void Salvar()
    {
        StreamWriter arquivo = new StreamWriter("bandas.txt");

        foreach (Banda banda in listaBanda)
        {
            arquivo.WriteLine(banda.Nome + "|" + banda.Genero + "|" +
                banda.Integrantes + "|" + banda.Ranking);
        }

        arquivo.Close();

        Console.WriteLine("Dados salvos!");
    }

    static void Carregar()
    {
        if (File.Exists("bandas.txt"))
        {
            listaBanda.Clear();

            string[] linhas = File.ReadAllLines("bandas.txt");

            foreach (string linha in linhas)
            {
                string[] dados = linha.Split('|');

                Banda banda = new Banda();
                banda.Nome = dados[0];
                banda.Genero = dados[1];
                banda.Integrantes = int.Parse(dados[2]);
                banda.Ranking = int.Parse(dados[3]);

                listaBanda.Add(banda);
            }

            Console.WriteLine("Dados carregados!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado!");
        }
    }

    static void BuscarRanking()
    {
        Console.Write("Digite o ranking: ");
        int ranking = int.Parse(Console.ReadLine());

        foreach (Banda banda in listaBanda)
        {
            if (banda.Ranking == ranking)
            {
                Console.WriteLine(banda.Nome + " - " + banda.Genero);
            }
        }
    }

    static void BuscarGenero()
    {
        Console.Write("Digite o gênero: ");
        string genero = Console.ReadLine();

        foreach (Banda banda in listaBanda)
        {
            if (banda.Genero.ToLower() == genero.ToLower())
            {
                Console.WriteLine(banda.Nome + " - " + banda.Genero);
                Console.WriteLine("Integrantes: " + banda.Integrantes);
                Console.WriteLine("Ranking: " + banda.Ranking);
            }
        }
    }

    static void BuscarNome()
    {
        Console.Write("Digite o nome da banda: ");
        string nome = Console.ReadLine();

        foreach (Banda banda in listaBanda)
        {
            if (banda.Nome.ToLower() == nome.ToLower())
            {
                Console.WriteLine("Nome: " + banda.Nome);
                Console.WriteLine("Gênero: " + banda.Genero);
                Console.WriteLine("Integrantes: " + banda.Integrantes);
                Console.WriteLine("Ranking: " + banda.Ranking);
            }
        }
    }

    static void Excluir()
    {
        Console.Write("Digite o nome da banda: ");
        string nome = Console.ReadLine();

        for (int i = 0; i < listaBanda.Count; i++)
        {
            if (listaBanda[i].Nome.ToLower() == nome.ToLower())
            {
                listaBanda.RemoveAt(i);
                Console.WriteLine("Banda excluída!");
                return;
            }
        }

        Console.WriteLine("Banda não encontrada!");
    }

    static void Alterar()
    {
        Console.Write("Digite o nome da banda: ");
        string nome = Console.ReadLine();

        foreach (Banda banda in listaBanda)
        {
            if (banda.Nome.ToLower() == nome.ToLower())
            {
                Console.Write("Novo nome: ");
                banda.Nome = Console.ReadLine();

                Console.Write("Novo gênero: ");
                banda.Genero = Console.ReadLine();

                Console.Write("Novo número de integrantes: ");
                banda.Integrantes = int.Parse(Console.ReadLine());

                Console.Write("Novo ranking: ");
                banda.Ranking = int.Parse(Console.ReadLine());

                Console.WriteLine("Dados alterados!");
                return;
            }
        }

        Console.WriteLine("Banda não encontrada!");
    }

    static void Main(string[] args)
    {
        int opcao = 0;

        while (opcao != 9)
        {
            Console.WriteLine("\n--- MENU BANDAS ---");
            Console.WriteLine("1 - Cadastrar banda");
            Console.WriteLine("2 - Listar bandas");
            Console.WriteLine("3 - Salvar dados");
            Console.WriteLine("4 - Carregar dados");
            Console.WriteLine("5 - Buscar por ranking");
            Console.WriteLine("6 - Buscar por gênero");
            Console.WriteLine("7 - Buscar por nome");
            Console.WriteLine("8 - Excluir ou alterar banda");
            Console.WriteLine("9 - Sair");
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
                    BuscarRanking();
                    break;
                case 6:
                    BuscarGenero();
                    break;
                case 7:
                    BuscarNome();
                    break;
                case 8:
                    Console.WriteLine("1 - Excluir");
                    Console.WriteLine("2 - Alterar");
                    int escolha = int.Parse(Console.ReadLine());

                    if (escolha == 1)
                        Excluir();
                    else if (escolha == 2)
                        Alterar();
                    break;
            }
        }
    }
}
