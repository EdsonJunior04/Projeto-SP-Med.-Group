USE SP_Med_Group
GO

SELECT * FROM PACIENTE;
SELECT * FROM CONSULTA;
SELECT * FROM USUARIO;
SELECT * FROM MEDICO;
SELECT * FROM SITUACAO;
SELECT * FROM TIPOUSUARIO;
SELECT * FROM CLINICA;
SELECT * FROM ESPECIALIDADE;

--11. Utilizar funções nativas do banco de dados

--Mostrou a quantidade de usuários após realizar a importação do banco de dados
SELECT COUNT(idUsuario) FROM USUARIO
GO

--Converteu a data de nascimento do usuário para o formato (mm-dd-yyyy) na exibição

SELECT	 
CONVERT(VARCHAR, dataNasc, 110)  
FROM PACIENTE 
GO	

--5. Utilizar relacionamentos entre as tabelas do banco de dados

SELECT nomeMedico, nomeEspecialidade, nomePaciente, dataConsulta FROM CONSULTA [C]
INNER JOIN MEDICO [M]
ON C.idMedico = M.idMedico
INNER JOIN ESPECIALIDADE [E]
ON M.idEspecialidade = E.idEspecialidade
INNER JOIN PACIENTE [P]
ON C.idPACIENTE= P.idPACIENTE
GO







	
	