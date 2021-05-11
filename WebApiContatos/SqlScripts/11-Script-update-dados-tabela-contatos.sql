USE [AgendaDB]
GO

DECLARE 
	@RC varchar(10),
	@idPessoa INT,
	@nome varchar(200),
	@dataNascimento date,
	@observacoes varchar(400),
	@telefone varchar(11),
	@email varchar(200)

SET	@idPessoa = 1
SET	@nome = 'Joao'
SET	@dataNascimento = '2021-05-10'
SET	@observacoes = 'primeiro contato'
SET	@telefone = '84999166065'
SET	@email = 'carlos505monks@hotmail.com'

-- TODO: Defina valores de parâmetros aqui.

EXECUTE @RC = [dbo].[stp_Contatos_Upd]
	@idPessoa,
	@nome,
	@dataNascimento,
	@observacoes,
	@telefone,
	@email
GO