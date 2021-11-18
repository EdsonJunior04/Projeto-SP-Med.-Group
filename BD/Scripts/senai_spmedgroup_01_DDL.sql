CREATE DATABASE SP_MED_GROUP;
GO

--DROP DATABASE SP_MED_GROUP

USE SP_MED_GROUP;

--TIPO USUARIO

CREATE TABLE TIPOUSUARIO (
	idTipoUsuario TINYINT PRIMARY KEY IDENTITY,
	tipo VARCHAR(70) UNIQUE NOT NULL
);
GO

--SITUAÇÃO 

CREATE TABLE SITUACAO (
	idSituacao TINYINT PRIMARY KEY IDENTITY,
	descricao VARCHAR(70) UNIQUE NOT NULL
);
GO

--ESPECIALIZAÇÃO

CREATE TABLE ESPECIALIZACAO (
	idEspecializacao SMALLINT PRIMARY KEY IDENTITY,
	tituloEspecializacao VARCHAR(70) UNIQUE NOT NULL
);
GO

--INSTITUIÇÃO

CREATE TABLE INSTITUICAO (
	idInstituicao SMALLINT PRIMARY KEY IDENTITY,
	nomeFantasia VARCHAR(100) UNIQUE NOT NULL,
	razaoSocial VARCHAR(100) UNIQUE NOT NULL,
	endereco VARCHAR(150) UNIQUE NOT NULL,
	CNPJ VARCHAR(18) UNIQUE NOT NULL
);
GO

--USUARIO

CREATE TABLE USUARIO (
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario TINYINT FOREIGN KEY REFERENCES TIPOUSUARIO(idTipoUsuario),
	nome VARCHAR(100) NOT NULL,
	email VARCHAR(256) NOT NULL,
	senha VARCHAR(18) NOT NULL CHECK( len(senha) >= 8)
);
GO

--MEDICO

CREATE TABLE MEDICO (
	idMedico INT PRIMARY KEY IDENTITY,
	idEspecializacao SMALLINT FOREIGN KEY REFERENCES ESPECIALIZACAO(idEspecializacao),
	idInstituicao SMALLINT FOREIGN KEY REFERENCES INSTITUICAO(idInstituicao),
	idUsuario INT FOREIGN KEY REFERENCES USUARIO(idUsuario),
	CRM VARCHAR(7) UNIQUE NOT NULL
);
GO

--PACIENTE

CREATE TABLE PACIENTE (
	idPaciente INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES USUARIO(idUsuario),
	dataNascimento DATE NOT NULL,
	CPF CHAR(12) UNIQUE NOT NULL,
	RG CHAR(9) UNIQUE NOT NULL,
	telefone VARCHAR(12), 
	endereco VARCHAR(150) UNIQUE NOT NULL
);
GO

--CONSULTA
CREATE TABLE CONSULTA (
	idConsulta INT PRIMARY KEY IDENTITY,
	idMedico INT FOREIGN KEY REFERENCES MEDICO(idMedico),
	idSituacao TINYINT FOREIGN KEY REFERENCES SITUACAO(idSituacao) DEFAULT(1),
	idPaciente INT FOREIGN KEY REFERENCES PACIENTE(idPaciente),
	dataConsulta DATETIME NOT NULL,
	descricao VARCHAR(50)
);
GO

--ImagemUsuario
CREATE TABLE IMAGEMUSUARIO(
	id INT PRIMARY KEY IDENTITY(1,1),
	idUsuario INT NOT NULL UNIQUE FOREIGN KEY REFERENCES USUARIO(idUsuario),
	binario VARBINARY(MAX) NOT NULL,
	mimeType VARCHAR(30) NOT NULL,
	nomeArquivo VARCHAR(250) NOT NULL,
	data_inclusao DATETIME DEFAULT GETDATE() NULL
);
GO