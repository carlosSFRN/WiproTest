USE AgendaDB

CREATE TABLE Contatos
(
	idPessoa INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nome VARCHAR(200) NOT NULL,
	dataNascimento DATE NOT NULL,
	observacoes VARCHAR(400)
)