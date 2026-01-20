-- Script SQL para criar o banco de dados da Biblioteca Escolar
-- Execute este script no phpMyAdmin ou MySQL Workbench

CREATE DATABASE IF NOT EXISTS biblioteca_escolar;
USE biblioteca_escolar;

-- Tabela de Utilizadores
CREATE TABLE IF NOT EXISTS Utilizadores (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Turma VARCHAR(50),
    Contacto VARCHAR(50)
);

-- Tabela de Livros
CREATE TABLE IF NOT EXISTS Livros (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Titulo VARCHAR(100) NOT NULL,
    Autor VARCHAR(100) NOT NULL,
    Ano INT,
    Estado ENUM('Disponível', 'Emprestado') DEFAULT 'Disponível'
);

-- Tabela de Empréstimos
CREATE TABLE IF NOT EXISTS Emprestimos (
    ID_Emprestimo INT AUTO_INCREMENT PRIMARY KEY,
    ID_Livro INT,
    ID_Utilizador INT,
    Data_Emprestimo DATE NOT NULL,
    Data_Devolucao DATE,
    FOREIGN KEY (ID_Livro) REFERENCES Livros(ID),
    FOREIGN KEY (ID_Utilizador) REFERENCES Utilizadores(ID)
);

-- Dados de exemplo (opcional)
INSERT INTO Utilizadores (Nome, Turma, Contacto) VALUES
('João Silva', '10A', 'joao@escola.com'),
('Maria Santos', '11B', 'maria@escola.com'),
('Pedro Almeida', '9C', 'pedro@escola.com');

INSERT INTO Livros (Titulo, Autor, Ano, Estado) VALUES
('O Pequeno Príncipe', 'Antoine de Saint-Exupéry', 1943, 'Disponível'),
('Dom Quixote', 'Miguel de Cervantes', 1605, 'Disponível'),
('1984', 'George Orwell', 1949, 'Disponível'),
('A Revolução dos Bichos', 'George Orwell', 1945, 'Disponível');