namespace ClientLab;

/// <summary>
/// Cliente pessoa jurídica.
/// Regra de negócio: CNPJ com 14 dígitos numéricos e "0001" nas quatro
/// posições anteriores aos dois dígitos verificadores (matriz).
/// </summary>
public class PessoaJuridica : Pessoa
{
    private string _cnpj = string.Empty;
    private string _razaoSocial = string.Empty;

    public string CNPJ
    {
        get => _cnpj;
        set
        {
            string digitos = new(value.Where(char.IsDigit).ToArray());

            if (digitos.Length != 14)
                throw new ArgumentException("O CNPJ deve conter exatamente 14 dígitos numéricos.", nameof(CNPJ));

            // Posições 9 a 12 (índices 8..11) = sufixo da filial; matriz = "0001"
            string sufixo = digitos.Substring(8, 4);
            if (sufixo != "0001")
                throw new ArgumentException(
                    $"CNPJ inválido: as quatro posições anteriores aos dígitos verificadores devem ser \"0001\" (informado: \"{sufixo}\").",
                    nameof(CNPJ));

            _cnpj = digitos;
        }
    }

    public string RazaoSocial
    {
        get => _razaoSocial;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("A razão social é obrigatória.", nameof(RazaoSocial));

            _razaoSocial = value.Trim();
        }
    }

    public PessoaJuridica(string nome, string cnpj, string razaoSocial) : base(nome)
    {
        CNPJ = cnpj;
        RazaoSocial = razaoSocial;
    }

    public string CnpjFormatado =>
        $"{CNPJ[..2]}.{CNPJ[2..5]}.{CNPJ[5..8]}/{CNPJ[8..12]}-{CNPJ[12..]}";

    public override string Descrever() =>
        $"[PJ] {Nome} | Razão Social: {RazaoSocial} | CNPJ: {CnpjFormatado}";
}
