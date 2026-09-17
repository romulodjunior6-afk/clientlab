using ClientLab;

Console.WriteLine("ClientLab - Cadastro de Clientes");
Console.WriteLine();

// Pessoa física válida
PessoaFisica pf1 = new PessoaFisica("Maria Silva", "12345678909", new DateTime(1990, 5, 20));
if (pf1.Validar())
{
    Console.WriteLine("Cadastrado: " + pf1.Nome + " - " + pf1.CalcularIdade() + " anos");
}

// Pessoa física menor de idade (deve dar erro)
PessoaFisica pf2 = new PessoaFisica("João Menor", "98765432100", new DateTime(2010, 3, 15));
if (pf2.Validar())
{
    Console.WriteLine("Cadastrado: " + pf2.Nome);
}

// Pessoa jurídica válida
PessoaJuridica pj1 = new PessoaJuridica("ClientLab", "12345678000195", "ClientLab Tecnologia LTDA");
if (pj1.Validar())
{
    Console.WriteLine("Cadastrado: " + pj1.RazaoSocial + " - CNPJ " + pj1.CNPJ);
}

// Pessoa jurídica com filial 0002 (deve dar erro)
PessoaJuridica pj2 = new PessoaJuridica("Filial", "12345678000276", "Filial LTDA");
if (pj2.Validar())
{
    Console.WriteLine("Cadastrado: " + pj2.RazaoSocial);
}

// Pessoa jurídica com CNPJ curto (deve dar erro)
PessoaJuridica pj3 = new PessoaJuridica("Curto", "1234567890001", "Curto LTDA");
if (pj3.Validar())
{
    Console.WriteLine("Cadastrado: " + pj3.RazaoSocial);
}
