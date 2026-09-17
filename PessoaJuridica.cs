namespace ClientLab;

public class PessoaJuridica : Pessoa
{
    public string CNPJ { get; set; }
    public string RazaoSocial { get; set; }

    public PessoaJuridica(string nome, string cnpj, string razaoSocial) : base(nome)
    {
        CNPJ = cnpj;
        RazaoSocial = razaoSocial;
    }

    public bool Validar()
    {
        // precisa ter 14 caracteres e todos numéricos
        if (CNPJ.Length != 14 || !CNPJ.All(char.IsDigit))
        {
            Console.WriteLine("Erro: o CNPJ deve ter 14 dígitos numéricos.");
            return false;
        }

        // posições 9 a 12 (antes dos 2 dígitos verificadores) devem ser 0001
        string filial = CNPJ.Substring(8, 4);
        if (filial != "0001")
        {
            Console.WriteLine("Erro: o CNPJ deve ter 0001 antes dos dígitos verificadores.");
            return false;
        }

        return true;
    }
}
