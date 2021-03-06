USE [AgendaDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[stp_Contatos_Sel] 
AS
BEGIN
	BEGIN TRY
		SET NOCOUNT ON
		SET XACT_ABORT ON

		DECLARE 
			@MsgErro VARCHAR(255),
			@idPessoaScope INT

		SELECT idPessoa, nome, dataNascimento, observacoes, telefone, email
		FROM Contatos (NOLOCK)

		RETURN 0
	END TRY

	BEGIN CATCH
		SET @MsgErro = ERROR_MESSAGE()
		RAISERROR(@MsgErro, 16, 1)

		RETURN 1
	END CATCH
END