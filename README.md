# ClientLab – Projeto Prático Parte 1

Sistema de cadastro de clientes em C# (.NET 8) com classes base de **Pessoa Física** e **Pessoa Jurídica**.

## Estrutura
- `Pessoa.cs` – classe abstrata base (propriedade `Nome`)
- `PessoaFisica.cs` – `CPF`, `DataNascimento`; valida idade mínima de 18 anos
- `PessoaJuridica.cs` – `CNPJ`, `RazaoSocial`; valida 14 dígitos e sufixo `0001`
- `Program.cs` – demonstração com casos válidos e inválidos

## Como executar
```bash
dotnet run
```

## Depuração no VS Code
Abra a pasta, coloque breakpoints em `PessoaFisica.cs` / `PessoaJuridica.cs` e pressione F5 (extensão C# Dev Kit).
