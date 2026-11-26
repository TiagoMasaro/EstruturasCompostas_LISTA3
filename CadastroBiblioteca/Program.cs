using System;
using System.Collections.Generic;

class Program
{
    static List<Livro> listaLivros = new List<Livro>();

    static void Cadastrar()
    {
        Livro livro = new Livro();

        Console.Write("Título: ");
        livro.Titulo = Console.ReadLine();

        Console.Write("Autor: ");
        livro.Autor = Console.ReadLine();

        Console.Write("Ano: ");
        livro.Ano = int.Parse(Console.ReadLine());

        Console.Write("Prateleira: ");
        livro.Prateleira = Console.ReadLine();

        listaLivros.Add(livro);

        Console.WriteLine("Livro cadastrado!");
    }

    static void Buscar()
    {
        Console.Write("Digite o título do livro: ");
        string titulo = Console.ReadLine();

        foreach (Livro livro in listaLivros)
        {
            if (livro.Titulo.ToLower() == titulo.ToLower())
            {
                Console.WriteLine("Título: " + livro.Titulo);
                Console.WriteLine("Prateleira: " + livro.Prateleira);
                return;
            }
        }

        Console.WriteLine("Livro não encontrado!");
    }

    static void Listar()
    {
        foreach (Livro livro in listaLivros)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Título: " + livro.Titulo);
            Console.WriteLine("Autor: " + livro.Autor);
            Console.WriteLine("Ano: " + livro.Ano);
            Console.WriteLine("Prateleira: " + livro.Prateleira);
        }
    }

    static void BuscarAno()
    {
        Console.Write("Digite um ano: ");
        int ano = int.Parse(Console.ReadLine());

        foreach (Livro livro in listaLivros)
        {
            if (livro.Ano > ano)
            {
                Console.WriteLine(livro.Titulo + " - " + livro.Ano);
            }
        }
    }

    static void Main(string[] args)
    {
        int opcao = 0;

        while (opcao != 5)
        {
            Console.WriteLine("\n--- MENU BIBLIOTECA ---");
            Console.WriteLine("1 - Cadastrar livro");
            Console.WriteLine("2 - Buscar livro");
            Console.WriteLine("3 - Listar livros");
            Console.WriteLine("4 - Buscar livros por ano");
            Console.WriteLine("5 - Sair");
            Console.Write("Opção: ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Cadastrar();
                    break;
                case 2:
                    Buscar();
                    break;
                case 3:
                    Listar();
                    break;
                case 4:
                    BuscarAno();
                    break;
            }
        }
    }
}
