USE SP_Med_Group
GO

	INSERT INTO TIPOUSUARIO ( nomeTipoU)
	VALUES ('Administrador'), ('Medico'), ('Paciente');
	GO

	INSERT INTO USUARIO (idTipoU, nome, email, senha)
	VALUES 
	(1,'Adm','adm@adm.com', 'adm12345'), 
	(2,'Ricardo','ricardo.lemos@spmedicalgroup.com.br', 'xxxxxxxx' ), 
	(2,'Roberto','roberto.porssale@spmedicalgroup.com.br', 'xxxxxxxx' ),
	(2,'Helena','helena.strada@spmedicalgroup.com.br', 'xxxxxxxx' ), 
	(3,'Ligia','ligia@gmail.com', 'xxxxxxxx'),
	(3,'Alexandre','alexandre@gmail.com', 'xxxxxxxx'), 
	(3,'Fernando','fernando@gmail.com', 'xxxxxxxx'), 
	(3,'Henrique','henrique@gmail.com', 'xxxxxxxx'), 
	(3,'João','joao@hotmail.com', 'xxxxxxxx'), 
	(3,'Bruno','bruno@gmail.com', 'xxxxxxxx'), 
	(3,'Mariana','mariana@outlook.com', 'xxxxxxxx');
	GO

	INSERT INTO  MEDICO (idUsuario,idClinica, idEspecialidade, nomeMedico,crm)
	VALUES (2,1,2,'Ricardo Lemos', '54356-SP'),(3,1,17,'Roberto Porssale', '53452-SP'), (4,1,16,'Helena Strada','65463-SP');
	GO

	
	INSERT INTO PACIENTE (idUsuario, nomePaciente,dataNasc, telefone,  rg, cpf	, endereco)
	VALUES 
	(5,'Ligia','13/10/1983','11 34567654', '435225435', '94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'),
	(6,'Alexandre', '23/7/2001','11 987656543','326543457', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'),
	(7,'Fernando',  '10/10/1978', '11 972084453', '546365253', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200'),
	(8,' Henrique',  '13/10/1985','11 34566543', '543663625', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
	(9,'João', '27/8/1975', '11 76566377','325444441', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'),
	(10,'Bruno', '21/3/1972','11 954368769', '545662667', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001'),
	(11,' Mariana ','05/03/2018','','545662668', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
	GO



	INSERT INTO CONSULTA (idPaciente, idMedico, idSituacao, dataConsulta, descricao)
	VALUES
	(7,1,1, '20/1/20  15:00',''),
	(2,3,2, '01/06/2020 10:00', ''),
	(3,3,1, '02/07/2020 11:00', ''),
	(2,3,1,'02/06/2018 10:00', ''),
	(4,3,2,'02/07/2019 11:00',''),
	(7,3,3,'03/08/2020 15:00',''),
	(4,3,3,'03/09/2018 11:00','');
	GO	


	INSERT INTO CLINICA ( nomeClinica, cnpj,RazaoSocial, endereco, telefone, horarioFuncionamento)
	VALUES
	('Clinica Possarle', '86.400.902/0001-30', 'SP Medical Group', 'Av. Barão Limeira, 532, São Paulo, SP', '4002-8922', 'Das 6:00 ás 18:00');
	GO

	INSERT INTO ESPECIALIDADE (nomeEspecialidade)
	VALUES 
	('Acupuntura'), ( 'Anestesiologia'), ('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),('Cirurgia da Mão'),('Cirurgia do Aparelho Digestivo'),
	('Cirurgia Geral'),('Cirurgia Pediátrica'),('Cirurgia Plástica'),('Cirurgia Torácica'),('Cirurgia Vascular'),('Dermatologia'),
	('Radioterapia'),('Urologia'),('Pediatria'),('Psiquiatria');
	GO

	INSERT INTO SITUACAO ( nomeSituacao)
	VALUES 
	('Realizada'), ('Cancelada'), ('Agendada');
	GO






	