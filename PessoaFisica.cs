namespace ClientLab;

public class PessoaFisica : Pessoa
{
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }

    public PessoaFisica(string nome, string cpf, DateTime dataNascimento) : base(nome)
    {
        CPF = cpf;
        DataNascimento = dataNascimento;
    }

    public int CalcularIdade()
    {
        int idade = DateTime.Today.Year - DataNascimento.Year;

        // se ainda não fez aniversário este ano, tira 1
        if (DataNascimento.Date > DateTime.Today.AddYears(-idade))
        {
            idade--;
        }

        return idade;
    }

    public bool Validar()
    {
        if (CalcularIdade() < 18)
        {
            Console.WriteLine("Erro: só é permitido cadastrar pessoas com 18 anos ou mais.");
            return false;
        }

        return true;
    }
}
