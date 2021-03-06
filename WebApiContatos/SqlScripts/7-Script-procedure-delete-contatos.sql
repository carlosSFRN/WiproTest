USE [AgendaDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[stp_Contatos_Del] (
	@idPessoa INT
)
AS
BEGIN
	BEGIN TRY
		SET NOCOUNT ON
		SET XACT_ABORT ON

		DECLARE 
			@MsgErro VARCHAR(255),
			@Retorno VARCHAR(20)

		DELETE FROM Contatos 
		WHERE idPessoa = @idPessoa

		SET @Retorno = 'OK'

		SELECT @Retorno as Retorno

		RETURN 0
	END TRY

	BEGIN CATCH
		SET @MsgErro = ERROR_MESSAGE()
		RAISERROR(@MsgErro, 16, 1)

		RETURN 1
	END CATCH
END