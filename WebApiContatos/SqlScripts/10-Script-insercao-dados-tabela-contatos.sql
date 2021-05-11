USE [AgendaDB]
GO

DECLARE 
	@RC varchar(10),
	@nome varchar(200),
	@dataNascimento date,
	@observacoes varchar(400),
	@telefone varchar(11),
	@email varchar(200)

SET	@nome = 'Carlos'
SET	@dataNascimento = '2021-05-10'
SET	@observacoes = 'primeiro contato'
SET	@telefone = '84999166067'
SET	@email = 'carlos505monks@hotmail.com'

-- TODO: Defina valores de parâmetros aqui.

EXECUTE @RC = [dbo].[stp_Contatos_Ins]
	@nome,
	@dataNascimento,
	@observacoes,
	@telefone,
	@email
GO


