# Biblioteca Escolar - Arquitetura em Camadas

Este projeto foi reestruturado com uma arquitetura em camadas clara e organizada, separando as responsabilidades em diferentes módulos para melhor manutenção e escalabilidade.

## Estrutura do Projeto

```
BibliotecaEscolar/
├── Models/                 # Classes de dados (Entities)
│   ├── Livro.vb           # Classe modelo para livros
│   ├── Utilizador.vb       # Classe modelo para utilizadores
│   └── Emprestimo.vb       # Classe modelo para empréstimos
├── DAL/                    # Data Access Layer (Acesso a dados)
│   ├── DatabaseConnection.vb    # Conexão com banco de dados
│   ├── LivroDAL.vb             # Operações CRUD para livros
│   ├── UtilizadorDAL.vb         # Operações CRUD para utilizadores
│   └── EmprestimoDAL.vb         # Operações para empréstimos
├── Forms/                  # Interface do usuário
│   ├── FormMain.vb         # Formulário principal
│   ├── FormLivros.vb       # Gestão de livros
│   ├── FormUtilizadores.vb # Gestão de utilizadores
│   └── FormEmprestimos.vb  # Gestão de empréstimos
└── My Project/             # Configurações do projeto VB.NET
```

## Melhorias Implementadas

### 1. **Models (Camada de Modelos)**
- **Livro**: Propriedades ID, Título, Autor, Ano, Estado
- **Utilizador**: Propriedades ID, Nome, Turma, Contacto
- **Emprestimo**: Propriedades ID_Emprestimo, ID_Livro, ID_Utilizador, Data_Emprestimo, Data_Devolucao
- Métodos auxiliares como `ToString()` e propriedades calculadas

### 2. **DAL (Data Access Layer)**
- **DatabaseConnection melhorado**:
  - Métodos genéricos para CRUD (ExecuteQuery, ExecuteNonQuery, ExecuteScalar)
  - Suporte a transações com `ExecuteTransaction`
  - Melhor tratamento de erros
  - Gestão automática de conexões

- **Classes DAL específicas**:
  - **LivroDAL**: Operações específicas para livros (CRUD completo, pesquisa, livros disponíveis)
  - **UtilizadorDAL**: Operações para utilizadores
  - **EmprestimoDAL**: Operações para empréstimos com transações

### 3. **Forms (Camada de Apresentação)**
- **Separação de responsabilidades**: Forms não contêm lógica de banco de dados
- **Uso de Models**: Trabalham com objetos fortemente tipados
- **Chamadas ao DAL**: Delegam operações de dados para a camada apropriada
- **Tratamento de erros centralizado**

## Recursos Técnicos

- **Framework**: .NET Framework 4.8
- **Banco de Dados**: MySQL 8.0.28
- **Linguagem**: Visual Basic .NET
- **Padrões**: Repository Pattern, Layered Architecture

## Vantagens da Nova Arquitetura

1. **Separação de responsabilidades**: Cada camada tem uma função específica
2. **Facilidade de manutenção**: Mudanças em uma camada não afetam outras
3. **Reutilização**: Classes DAL podem ser usadas em diferentes forms
4. **Testabilidade**: Camadas podem ser testadas independentemente
5. **Escalabilidade**: Fácil adicionar novas funcionalidades

## Compatibilidade

- ✅ Visual Studio Code
- ✅ Visual Studio
- ✅ .NET Framework 4.8
- ✅ MySql.Data 8.0.28

## Como Compilar

```bash
# No diretório do projeto
dotnet build
# ou
msbuild BibliotecaEscolar.vbproj
```

## Observações

- O projeto mantém compatibilidade total com o banco de dados existente
- Todas as funcionalidades originais foram preservadas
- A nova arquitetura permite fácil extensão e manutenção