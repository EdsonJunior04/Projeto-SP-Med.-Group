	USE SP_Med_Group
	GO

-- Mostrar a quantidade de usuários após realizar a importação do banco de dados
SELECT COUNT(*) 'Número de usuários cadastrados' FROM USUARIO
GO

-- Converter a data de nascimento do usuário para o formato (mm-dd-yyyy) na exibição
SELECT nomePaciente Paciente, Convert(varchar,dataNascimento, 105) 'Data de Nascimento' FROM PACIENTE
GO

-- Calcular a idade do usuário a partir da data de nascimento
SELECT nomePaciente Paciente, DATEDIFF(YEAR,dataNascimento,GETDATE()) Idade FROM PACIENTE
GO

SELECT	idConsulta,
		dataConsulta [Data da Consulta],
		nomePaciente Paciente,
		nomeUsuario [Nome de Usuário do Paciente],
		nomeMedico [Médico],
		nomeEspecialidade [Especialidade],
		CLINICA.nomeFantasia [Clínica],
		nomeSituacao [Situação da Consulta],
		CONSULTA.descricao [Descrção da Consulta]
FROM CONSULTA
LEFT JOIN SITUACAO
ON CONSULTA.idSituacao = SITUACAO.idSituacao
LEFT JOIN PACIENTE
ON CONSULTA.idPaciente = PACIENTE.idPaciente
LEFT JOIN MEDICO
ON CONSULTA.idMedico = MEDICO.idMedico
LEFT JOIN ESPECIALIDADE
ON MEDICO.idEspecialidade = ESPECIALIDADE.idEspecialidade
LEFT JOIN CLINICA
ON MEDICO.idClinica = CLINICA.idClinica
INNER JOIN USUARIO
ON PACIENTE.idUsuario = USUARIO.idUsuario
GO
	