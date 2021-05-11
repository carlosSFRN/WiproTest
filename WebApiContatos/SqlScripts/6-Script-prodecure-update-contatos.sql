USE AgendaDB

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE stp_Contatos_Upd (
	@idPessoa INT,
	@nome VARCHAR(200),
	@dataNascimento DATE,
	@observacoes VARCHAR(400),
	@telefone VARCHAR(11),
	@email VARCHAR(200)
)
AS
BEGIN
	BEGIN TRY
		SET NOCOUNT ON
		SET XACT_ABORT ON

		DECLARE 
			@MsgErro VARCHAR(255),
			@Retorno VARCHAR(20)

		UPDATE Contatos SET
			nome = @nome,
			dataNascimento = @dataNascimento,
			observacoes = @observacoes,
			telefone = @telefone,
			email = @email
		WHERE idPessoa = @idPessoa

		SET @Retorno = 'OK'

		SELECT @Retorno AS Retorno

		RETURN 0
	END TRY

	BEGIN CATCH
		SET @MsgErro = ERROR_MESSAGE()
		RAISERROR(@MsgErro, 16, 1)

		RETURN 1
	END CATCH
END