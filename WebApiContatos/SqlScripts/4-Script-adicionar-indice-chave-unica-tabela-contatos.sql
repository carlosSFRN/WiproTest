USE AgendaDB

CREATE UNIQUE INDEX ix_unique_contatos_telefone
ON Contatos(telefone)