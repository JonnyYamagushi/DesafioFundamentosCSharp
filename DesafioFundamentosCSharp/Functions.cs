using System.Text.RegularExpressions;

namespace DesafioFundamentosCSharp;

/// <summary>
/// Classe utilitária com métodos auxiliares para validação e leitura de entradas do usuário,
/// incluindo validação de nomes, números, e formatação de texto.
/// </summary>
static class Functions
{
    /// <summary>
    /// Valida se o nome fornecido contém apenas letras (incluindo acentuadas) e espaços.
    /// Rejeita entradas com caracteres inválidos ou nomes com menos de 2 letras (desconsiderando espaços).
    /// </summary>
    /// <param name="nome">Texto a ser validado como nome.</param>
    /// <returns>True se for um nome válido; caso contrário, false.</returns>
    static bool ValidName(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return false;

        nome = nome.Trim();

        // Aceita letras maiúsculas, minúsculas, acentuadas e espaço
        Regex regex = new Regex(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$");

        return regex.IsMatch(nome) && nome.Replace(" ", "").Length >= 2;
    }

    /// <summary>
    /// Verifica se uma string representa um número decimal válido, com a opção de permitir ou não números negativos.
    /// </summary>
    /// <param name="Value">Texto a ser validado.</param>
    /// <param name="AllowNegative">Indica se números negativos são permitidos (padrão: true).</param>
    /// <returns>True se for um número válido; caso contrário, false.</returns>
    static bool IsNumeric(string Value, bool AllowNegative = true)
    {
        decimal resultado;
        if (decimal.TryParse(Value, out resultado))
        {
            if (resultado < 0 && !AllowNegative)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Solicita ao usuário a entrada de um número válido.
    /// Continua solicitando até que o valor digitado seja reconhecido como numérico.
    /// </summary>
    /// <param name="prompt">Mensagem a ser exibida ao solicitar a entrada.</param>
    /// <returns>Texto numérico validado como string.</returns>
    public static string ReadValidNumber(string prompt)
    {
        string? input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input) || !Functions.IsNumeric(input))
            {
                Console.WriteLine("Valor inválido. Tente novamente.\n");
            }

        } while (string.IsNullOrWhiteSpace(input) || !Functions.IsNumeric(input));

        return input;
    }

    /// <summary>
    /// Solicita ao usuário a entrada de um nome válido.
    /// Continua solicitando até que o nome atenda aos critérios de validação e retorna o nome com a primeira letra maiúscula.
    /// </summary>
    /// <param name="prompt">Mensagem a ser exibida ao solicitar a entrada.</param>
    /// <param name="errorMessage">Mensagem a ser exibida quando o nome for inválido.</param>
    /// <returns>Nome validado e formatado com a primeira letra maiúscula.</returns>
    public static string ReadValidName(string prompt, string errorMessage)
    {
        string? input;
        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input) || !Functions.ValidName(input))
            {
                Console.WriteLine($"{errorMessage}\n");
            }

        } while (string.IsNullOrWhiteSpace(input) || !Functions.ValidName(input));

        return Capitalize(input);
    }

    /// <summary>
    /// Formata uma string para que a primeira letra fique maiúscula e o restante em minúsculo.
    /// Ignora entradas nulas ou em branco.
    /// </summary>
    /// <param name="input">Texto a ser capitalizado.</param>
    /// <returns>Texto com a primeira letra maiúscula e o restante minúsculo.</returns>
    static string Capitalize(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "";

        input = input.Trim().ToLower();
        return char.ToUpper(input[0]) + input.Substring(1);
    }
}