using ClientLab;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("=== ClientLab - Cadastro de Clientes ===\n");

var clientes = new List<Pessoa>();

// ---------- Casos válidos ----------
TentarCadastrar(() => new PessoaFisica("Maria Silva", "123.456.789-09", new DateTime(1990, 5, 20)));
TentarCadastrar(() => new PessoaJuridica("ClientLab", "12.345.678/0001-95", "ClientLab Tecnologia LTDA"));

// ---------- Casos inválidos (devem exibir mensagem de erro) ----------
TentarCadastrar(() => new PessoaFisica("João Menor", "987.654.321-00", DateTime.Today.AddYears(-16)));
TentarCadastrar(() => new PessoaJuridica("Filial X", "12.345.678/0002-76", "Filial X LTDA"));
TentarCadastrar(() => new PessoaJuridica("CNPJ Curto", "1234567890001", "Empresa Curta LTDA"));

Console.WriteLine("\n--- Clientes cadastrados ---");
foreach (var cliente in clientes)
    Console.WriteLine(cliente.Descrever());

void TentarCadastrar(Func<Pessoa> criar)
{
    try
    {
        var pessoa = criar();
        clientes.Add(pessoa);
        Console.WriteLine($"✔ Cadastrado: {pessoa.Nome}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"✘ Erro: {ex.Message}");
    }
}
