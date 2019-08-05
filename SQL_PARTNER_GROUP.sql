use PARTNER_TESTE

--DROP TABLE Marcas
--DROP TABLE Patrimonios

CREATE TABLE Marcas
(
	Nome varchar(500),
	MARCA_ID INT PRIMARY KEY IDENTITY(1,1)
)

CREATE TABLE Patrimonios
(
	Nome varchar(500),
	PATRIMONIO_ID INT PRIMARY KEY IDENTITY(1,1),
	MARCA_ID int not null,
	DESCRICAO varchar(500),
	NUM_TOMBO int not null
)