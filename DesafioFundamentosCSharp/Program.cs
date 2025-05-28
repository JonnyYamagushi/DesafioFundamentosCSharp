using DesafioFundamentosCSharp;
using System.Globalization;
using System.Text.RegularExpressions;

/// <summary>
/// Classe principal do desafio de fundamentos C# da Rocketseat.
/// Contém o menu principal interativo e os métodos responsáveis por executar
/// cada funcionalidade do sistema: saudação personalizada, nome completo,
/// operações matemáticas, contagem de caracteres, validação de placa de veículo
/// (modelo antigo) e exibição de data e hora em diferentes formatos.
/// </summary>
class Program
{
    /// <summary>
    /// Método principal que exibe um menu interativo no console para o usuário.
    /// Permite escolher entre várias funcionalidades relacionadas a fundamentos de C#:
    /// boas-vindas, nome completo, operações matemáticas, contagem de caracteres,
    /// validação de placa brasileira (modelo antigo) e exibição de data/hora.
    /// O programa continua em execução até que o usuário selecione a opção de sair.
    /// </summary>
    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("=== Desafio Rocketseat: Fundamentos C# ===");
            Console.WriteLine("1. Boas-vindas com nome");
            Console.WriteLine("2. Nome completo (nome + sobrenome)");
            Console.WriteLine("3. Operações com dois números");
            Console.WriteLine("4. Contador de caracteres (ignorando espaços)");
            Console.WriteLine("5. Validador de placa brasileira (modelo antigo)");
            Console.WriteLine("6. Exibição de data e hora em formatos diversos");
            Console.WriteLine("0. Sair");
            Console.Write("\nEscolha uma opção: ");

            string? Option = Console.ReadLine()?.Trim();

            switch (Option)
            {
                case "1":
                    Welcome();
                    break;
                case "2":
                    FullName();
                    break;
                case "3":
                    Operations();
                    break;
                case "4":
                    CharacterCounter();
                    break;
                case "5":
                    PlateValidator();
                    break;
                case "6":
                    ShowDate();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    /// <summary>
    /// Solicita o nome do usuário, valida a entrada e exibe uma mensagem de boas-vindas.
    /// Continua solicitando até que o nome seja considerado válido, ignorando entradas vazias ou inválidas.
    /// </summary>
    static void Welcome()
    {
        Console.Clear();

        string? name;
        Console.WriteLine("=== Opção: 1. Boas-vindas com nome ===");

        name = Functions.ReadValidName("Digite seu nome:", "Nome inválido. Tente novamente.\n");

        Console.WriteLine($"\nOlá, {name}! Seja Muito Bem-Vindo!");
    }

    /// <summary>
    /// Solicita ao usuário o nome e o sobrenome, valida ambos, e exibe o nome completo.
    /// Continua solicitando entradas até que sejam consideradas válidas.
    /// </summary>
    static void FullName()
    {
        Console.Clear();

        string? name;
        string? lastName;

        Console.WriteLine("=== Opção: 2. Nome completo (nome + sobrenome) ===");

        name = Functions.ReadValidName("Digite seu nome:", "Nome inválido. Tente novamente.\n");
        lastName = Functions.ReadValidName("Digite seu nome:", "Sobrenome inválido. Tente novamente.\n");

        Console.WriteLine($"\nNome completo: {name} {lastName}");
    }

    /// <summary>
    /// Solicita ao usuário dois valores numéricos válidos como texto, realiza a conversão para double,
    /// executa operações matemáticas (soma, subtração, multiplicação, divisão e média) e exibe os resultados.
    /// Aceita tanto vírgula quanto ponto como separador decimal.
    /// </summary>
    static void Operations()
    {
        Console.Clear();

        Console.WriteLine("=== Opção: 3. Operações com dois números ===");

        double n1 = Convert.ToDouble(Functions.ReadValidNumber("Digite o primeiro número: ").Replace(',', '.'), CultureInfo.InvariantCulture);
        double n2 = Convert.ToDouble(Functions.ReadValidNumber("Digite o segundo número: ").Replace(',', '.'), CultureInfo.InvariantCulture);

        Console.WriteLine($"\nResultados das operações com {n1} e {n2}:");
        Console.WriteLine($"\nSoma: {n1 + n2}");
        Console.WriteLine($"Subtração: {n1 - n2}");
        Console.WriteLine($"Multiplicação: {n1 * n2}");

        if (n2 != 0)
        {
            Console.WriteLine($"Divisão: {n1 / n2}");
        }
        else
        {
            Console.WriteLine("Divisão: impossível dividir por zero.");
        }

        Console.WriteLine($"Média: {(n1 + n2) / 2}");
    }

    /// <summary>
    /// Solicita ao usuário um texto e exibe a quantidade de caracteres,
    /// desconsiderando os espaços em branco. Repete a solicitação até que um texto válido seja inserido.
    /// </summary>
    static void CharacterCounter()
    {
        Console.Clear();

        Console.WriteLine("=== Opção: 4. Contador de caracteres (ignorando espaços) ===");

        string? text;
        do
        {
            Console.WriteLine("Por favor, digite uma palavra, frase ou texto para contar os caracteres (espaços serão ignorados):");
            text = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Nenhum texto foi digitado. Tente novamente.");
            }

        } while (string.IsNullOrWhiteSpace(text));
                
        int characterCount = Regex.Replace(text, @"\s+", "").Length;
        Console.WriteLine($"\nO texto digitado possui {characterCount} caracteres (sem contar os espaços).");
    }

    /// <summary>
    /// Solicita ao usuário uma placa de veículo e valida se ela está no formato do modelo antigo brasileiro (AAA1234),
    /// onde os três primeiros caracteres são letras e os quatro últimos são dígitos.
    /// Exibe se a placa é válida ou inválida.
    /// </summary>
    static void PlateValidator()
    {
        Console.Clear();

        Console.WriteLine("=== Opção: 5. Validador de placa brasileira (modelo antigo) ===");

        string? placa;

        do
        {
            Console.WriteLine("Digite a placa do veículo:");
            placa = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Nenhum texto foi digitado. Tente novamente.");
            }

        } while (string.IsNullOrWhiteSpace(placa));

        bool formatoValido = placa.Length == 7 &&
                             char.IsLetter(placa[0]) &&
                             char.IsLetter(placa[1]) &&
                             char.IsLetter(placa[2]) &&
                             char.IsDigit(placa[3]) &&
                             char.IsDigit(placa[4]) &&
                             char.IsDigit(placa[5]) &&
                             char.IsDigit(placa[6]);

        Console.WriteLine(formatoValido ? "Verdadeiro (placa válida)" : "Falso (placa inválida)");
    }

    /// <summary>
    /// Exibe a data e hora atual em diversos formatos:
    /// formato completo com dia da semana e mês por extenso, apenas data, apenas hora,
    /// e data com o mês por extenso no formato brasileiro.
    /// </summary>
    static void ShowDate()
    {
        Console.Clear();
        Console.WriteLine("=== Opção: 6. Exibição de data e hora em formatos diversos ===");

        DateTime now = DateTime.Now;
        var culture = new CultureInfo("pt-BR");

        Console.WriteLine($"Formato completo: {now.ToString("dddd, dd 'de' MMMM 'de' yyyy HH:mm:ss", culture)}");
        Console.WriteLine($"Apenas data: {now.ToString("dd/MM/yyyy")}");
        Console.WriteLine($"Apenas hora: {now.ToString("HH:mm")}");
        Console.WriteLine($"Data com mês por extenso: {now.ToString("dd 'de' MMMM 'de' yyyy", culture)}");
    }
}