namespace ClientLab;

/// <summary>
/// Classe base compartilhada por Pessoa Física e Pessoa Jurídica.
/// Concentra o atributo comum "Nome" e o encapsulamento da sua validação.
/// </summary>
public abstract class Pessoa
{
    private string _nome = string.Empty;

    public string Nome
    {
        get => _nome;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("O nome é obrigatório.", nameof(Nome));

            _nome = value.Trim();
        }
    }

    protected Pessoa(string nome)
    {
        Nome = nome;
    }

    public abstract string Descrever();
}
