using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Quantidade de cabeças de gado: ");
        int quantidade = int.Parse(Console.ReadLine());

        Gado[] gados = new Gado[quantidade];

        for (int i = 0; i < quantidade; i++)
        {
            gados[i] = new Gado();
            gados[i].Nascimento = new Data();

            Console.WriteLine("\nGado " + (i + 1));

            Console.Write("Código: ");
            gados[i].Codigo = int.Parse(Console.ReadLine());

            Console.Write("Litros de leite por semana: ");
            gados[i].Leite = double.Parse(Console.ReadLine());

            Console.Write("Alimento por semana em kg: ");
            gados[i].Alimento = double.Parse(Console.ReadLine());

            Console.Write("Mês de nascimento: ");
            gados[i].Nascimento.Mes = int.Parse(Console.ReadLine());

            Console.Write("Ano de nascimento: ");
            gados[i].Nascimento.Ano = int.Parse(Console.ReadLine());

            int idade = DateTime.Now.Year - gados[i].Nascimento.Ano;

            if (DateTime.Now.Month < gados[i].Nascimento.Mes)
            {
                idade--;
            }

            if (idade > 5 || gados[i].Leite < 40)
            {
                gados[i].Abate = "S";
            }
            else
            {
                gados[i].Abate = "N";
            }
        }

        int opcao = 0;

        while (opcao != 6)
        {
            Console.WriteLine("\n--- MENU FAZENDA ---");
            Console.WriteLine("1 - Total de leite");
            Console.WriteLine("2 - Total de alimento");
            Console.WriteLine("3 - Listar animais para abate");
            Console.WriteLine("4 - Salvar dados");
            Console.WriteLine("5 - Carregar dados");
            Console.WriteLine("6 - Sair");
            Console.Write("Opção: ");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                double totalLeite = 0;

                for (int i = 0; i < quantidade; i++)
                {
                    totalLeite += gados[i].Leite;
                }

                Console.WriteLine("Total de leite: " + totalLeite + " litros");
            }
            else if (opcao == 2)
            {
                double totalAlimento = 0;

                for (int i = 0; i < quantidade; i++)
                {
                    totalAlimento += gados[i].Alimento;
                }

                Console.WriteLine("Total de alimento: " + totalAlimento + " kg");
            }
            else if (opcao == 3)
            {
                for (int i = 0; i < quantidade; i++)
                {
                    if (gados[i].Abate == "S")
                    {
                        Console.WriteLine("Código: " + gados[i].Codigo);
                        Console.WriteLine("Leite: " + gados[i].Leite);
                        Console.WriteLine("Alimento: " + gados[i].Alimento);
                    }
                }
            }
            else if (opcao == 4)
            {
                StreamWriter arquivo = new StreamWriter("gado.txt");

                for (int i = 0; i < quantidade; i++)
                {
                    arquivo.WriteLine(gados[i].Codigo + "|" +
                        gados[i].Leite + "|" +
                        gados[i].Alimento + "|" +
                        gados[i].Nascimento.Mes + "|" +
                        gados[i].Nascimento.Ano + "|" +
                        gados[i].Abate);
                }

                arquivo.Close();

                Console.WriteLine("Dados salvos!");
            }
            else if (opcao == 5)
            {
                if (File.Exists("gado.txt"))
                {
                    string[] linhas = File.ReadAllLines("gado.txt");

                    quantidade = linhas.Length;
                    gados = new Gado[quantidade];

                    for (int i = 0; i < quantidade; i++)
                    {
                        string[] dados = linhas[i].Split('|');

                        gados[i] = new Gado();
                        gados[i].Nascimento = new Data();

                        gados[i].Codigo = int.Parse(dados[0]);
                        gados[i].Leite = double.Parse(dados[1]);
                        gados[i].Alimento = double.Parse(dados[2]);
                        gados[i].Nascimento.Mes = int.Parse(dados[3]);
                        gados[i].Nascimento.Ano = int.Parse(dados[4]);
                        gados[i].Abate = dados[5];
                    }

                    Console.WriteLine("Dados carregados!");
                }
                else
                {
                    Console.WriteLine("Arquivo não encontrado!");
                }
            }
        }
    }
}
