USE [AgendaDB]
GO

DECLARE 
	@RC varchar(10),
	@idPessoa INT

SET	@idPessoa = 1

-- TODO: Defina valores de parāmetros aqui.

EXECUTE @RC = [dbo].[stp_Contatos_Del]
	@idPessoa
GO