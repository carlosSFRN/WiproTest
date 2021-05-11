USE [AgendaDB]
GO

DECLARE @RC int
DECLARE @idPessoa int

SET @idPessoa = 3

EXECUTE @RC = stp_Contatos_Sel_Id 
   @idPessoa
GO


