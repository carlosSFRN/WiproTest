use AgendaDB

CREATE INDEX ix_contatos_nome
ON Contatos(nome);

CREATE INDEX ix_contatos_telefone
ON Contatos(telefone);
