# Sistema de Gestão de Biblioteca Escolar - VB.NET

## Descrição
Este é um sistema de gestão de biblioteca escolar desenvolvido em VB.NET com Windows Forms e MySQL. O sistema permite gerir utilizadores, livros e empréstimos.

## Requisitos do Sistema
- Windows 10/11
- .NET Framework 4.8
- Visual Studio 2022 (ou superior)
- XAMPP (para MySQL)

## Instalação

### 1. Instalar Pré-requisitos
1. **Visual Studio 2022**: Baixe e instale do site oficial da Microsoft
   - Durante a instalação, selecione a carga de trabalho "Desenvolvimento para Desktop com .NET"

2. **XAMPP**: Baixe e instale do site oficial do Apache Friends
   - Inicie o XAMPP e certifique-se de que o MySQL está em execução

3. **MySQL Connector/NET**: Será instalado automaticamente via NuGet quando o projeto for aberto

### 2. Configurar o Banco de Dados
1. Abra o phpMyAdmin através do XAMPP (geralmente em http://localhost/phpmyadmin)
2. Execute o script SQL `biblioteca_escolar_database.sql` para criar o banco de dados e tabelas
3. O script também inclui alguns dados de exemplo para teste

### 3. Configurar o Projeto
1. Abra o Visual Studio
2. Selecione "Abrir um projeto ou solução" e navegue até a pasta do projeto
3. Abra o arquivo `BibliotecaEscolar.sln`

### 4. Restaurar Pacotes NuGet
1. No Visual Studio, clique com o botão direito na solução no Solution Explorer
2. Selecione "Restaurar Pacotes NuGet"
3. Isso irá baixar e instalar o MySQL Connector/NET automaticamente

### 5. Configurar a Conexão com o Banco de Dados
1. Verifique o arquivo `BibliotecaEscolar\app.config`
2. Certifique-se de que a string de conexão está correta:
   ```xml
   <connectionStrings>
       <add name="BibliotecaEscolarDB" connectionString="Server=localhost;Database=biblioteca_escolar;Uid=root;Pwd=;" providerName="MySql.Data.MySqlClient" />
   </connectionStrings>
   ```
3. Se você usar uma senha diferente para o MySQL, atualize o parâmetro `Pwd`

### 6. Compilar e Executar
1. Pressione F5 ou clique no botão "Iniciar" para compilar e executar o projeto
2. O sistema será iniciado com o menu principal

## Funcionalidades

### Menu Principal
- **Gerir Utilizadores**: Acessar o módulo de gestão de utilizadores
- **Gerir Livros**: Acessar o módulo de gestão de livros
- **Gerir Empréstimos**: Acessar o módulo de gestão de empréstimos
- **Sair**: Fechar o aplicativo

### Gestão de Utilizadores
- **Inserir**: Adicionar um novo utilizador
- **Editar**: Modificar dados de um utilizador existente
- **Eliminar**: Remover um utilizador
- **Limpar**: Limpar os campos do formulário
- **Voltar**: Retornar ao menu principal

### Gestão de Livros
- **Inserir**: Adicionar um novo livro
- **Editar**: Modificar dados de um livro existente
- **Eliminar**: Remover um livro
- **Pesquisar**: Buscar livros por título ou autor
- **Limpar**: Limpar os campos do formulário
- **Voltar**: Retornar ao menu principal

### Gestão de Empréstimos
- **Registrar Empréstimo**: Registrar um novo empréstimo de livro
- **Registrar Devolução**: Registrar a devolução de um livro emprestado
- **Limpar**: Limpar os campos do formulário
- **Voltar**: Retornar ao menu principal

## Estrutura do Banco de Dados

### Tabelas
1. **Utilizadores**: Armazena informações sobre os utilizadores da biblioteca
   - ID (Chave primária)
   - Nome
   - Turma
   - Contacto

2. **Livros**: Armazena informações sobre os livros
   - ID (Chave primária)
   - Título
   - Autor
   - Ano
   - Estado (Disponível/Emprestado)

3. **Emprestimos**: Armazena informações sobre os empréstimos
   - ID_Emprestimo (Chave primária)
   - ID_Livro (Chave estrangeira para Livros)
   - ID_Utilizador (Chave estrangeira para Utilizadores)
   - Data_Emprestimo
   - Data_Devolucao

## Solução de Problemas

### Problemas de Conexão com o Banco de Dados
1. Verifique se o MySQL está em execução no XAMPP
2. Verifique se a string de conexão está correta no arquivo `app.config`
3. Verifique se o usuário e senha do MySQL estão corretos

### Erros de Compilação
1. Certifique-se de que todos os pacotes NuGet foram restaurados
2. Verifique se o .NET Framework 4.8 está instalado
3. Limpe e reconstrua a solução

### Problemas com o Visual Studio
1. Certifique-se de ter a carga de trabalho "Desenvolvimento para Desktop com .NET" instalada
2. Tente reiniciar o Visual Studio
3. Verifique se há atualizações disponíveis para o Visual Studio

## Contribuição
Este projeto foi desenvolvido como um sistema de gestão de biblioteca escolar. Sinta-se à vontade para modificar e expandir conforme necessário.

## Licença
Este projeto é de código aberto e pode ser usado livremente para fins educacionais.