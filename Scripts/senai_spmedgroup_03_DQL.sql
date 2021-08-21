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

--11. Utilizar fun��es nativas do banco de dados

--Mostrou a quantidade de usu�rios ap�s realizar a importa��o do banco de dados
SELECT COUNT(idUsuario) FROM USUARIO
GO

--Converteu a data de nascimento do usu�rio para o formato (mm-dd-yyyy) na exibi��o

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







	
	