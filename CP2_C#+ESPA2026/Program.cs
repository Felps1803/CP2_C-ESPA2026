using System;

class Program
{
    const double MEDIA_APROVACAO = 7.0;
    const double MEDIA_RECUPERACAO = 5.0;

    static string nomeAluno = "";
    static double[] notas = new double[3];

    static void Main()
    {
        int opcao;

        do
        {
            Console.WriteLine("\n=== CALCULADORA DE NOTAS ===");
            Console.WriteLine("1 - Cadastrar aluno");
            Console.WriteLine("2 - Lançar notas");
            Console.WriteLine("3 - Calcular média");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarAluno();
                    break;

                case 2:
                    LancarNotas();
                    break;

                case 3:
                    CalcularMedia();
                    break;

                case 4:
                    Console.WriteLine("Programa encerrado.");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        } while (opcao != 4);
    }

    static void CadastrarAluno()
    {
        Console.Write("Nome do aluno: ");
        nomeAluno = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(nomeAluno))
        {
            Console.Write("Nome inválido. Digite novamente: ");
            nomeAluno = Console.ReadLine();
        }

        Console.WriteLine("Aluno cadastrado!");
    }

    static void LancarNotas()
    {
        for (int i = 0; i < 3; i++)
        {
            double nota;

            while (true)
            {
                Console.Write($"Digite a {i + 1}ª nota: ");

                if (double.TryParse(Console.ReadLine(), out nota) &&
                    nota >= 0 && nota <= 10)
                {
                    notas[i] = nota;
                    break;
                }

                Console.WriteLine("Nota inválida. Digite um valor entre 0 e 10.");
            }
        }

        Console.WriteLine("Notas cadastradas!");
    }

    static void CalcularMedia()
    {
        double media = (notas[0] + notas[1] + notas[2]) / 3;

        Console.WriteLine($"Aluno: {nomeAluno}");
        Console.WriteLine($"Média: {media:F1}");

        ExibirSituacao(media);
    }

    static void ExibirSituacao(double media)
    {
        if (media >= MEDIA_APROVACAO)
        {
            Console.WriteLine("Aprovado");
        }
        else if (media >= MEDIA_RECUPERACAO)
        {
            Console.WriteLine("Recuperação");
        }
        else
        {
            Console.WriteLine("Reprovado");
        }
    }


}