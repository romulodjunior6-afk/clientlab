namespace ClientLab;

/// <summary>
/// Cliente pessoa física. Regra de negócio: somente maiores de 18 anos.
/// </summary>
public class PessoaFisica : Pessoa
{
    public const int IdadeMinima = 18;

    private string _cpf = string.Empty;
    private DateTime _dataNascimento;

    public string CPF
    {
        get => _cpf;
        set
        {
            string digitos = new(value.Where(char.IsDigit).ToArray());

            if (digitos.Length != 11)
                throw new ArgumentException("O CPF deve conter 11 dígitos numéricos.", nameof(CPF));

            _cpf = digitos;
        }
    }

    public DateTime DataNascimento
    {
        get => _dataNascimento;
        set
        {
            if (value > DateTime.Today)
                throw new ArgumentException("A data de nascimento não pode ser futura.", nameof(DataNascimento));

            int idade = CalcularIdade(value);
            if (idade < IdadeMinima)
                throw new ArgumentException(
                    $"Cadastro não permitido: a idade mínima é {IdadeMinima} anos (idade informada: {idade}).",
                    nameof(DataNascimento));

            _dataNascimento = value;
        }
    }

    public int Idade => CalcularIdade(DataNascimento);

    public PessoaFisica(string nome, string cpf, DateTime dataNascimento) : base(nome)
    {
        CPF = cpf;
        DataNascimento = dataNascimento;
    }

    private static int CalcularIdade(DateTime nascimento)
    {
        var hoje = DateTime.Today;
        int idade = hoje.Year - nascimento.Year;

        // Ainda não fez aniversário este ano
        if (nascimento.Date > hoje.AddYears(-idade))
            idade--;

        return idade;
    }

    public string CpfFormatado =>
        $"{CPF[..3]}.{CPF[3..6]}.{CPF[6..9]}-{CPF[9..]}";

    public override string Descrever() =>
        $"[PF] {Nome} | CPF: {CpfFormatado} | Nascimento: {DataNascimento:dd/MM/yyyy} ({Idade} anos)";
}
