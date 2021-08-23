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
	--Calculou a idade do usu�rio a partir da data de nascimento
	SELECT PACIENTE.nomePaciente,
	DATEDIFF (YEAR, dataNasc, GETDATE() ) Idade
	FROM PACIENTE
	GO


--12. Aplicar programa��o em banco de dados utilizando functions, stored procedures,
--triggers e eventos


--Criou uma fun��o para retornar a quantidade de m�dicos de uma determinada especialidade
	CREATE FUNCTION  Medicos (@especialidade VARCHAR (70))
	RETURNS TABLE AS RETURN(
	SELECT @especialidade AS ESPECIALIZACAO,  COUNT(idEspecialidade)  [ Quantidade de Medicos]  FROM ESPECIALIDADE
	WHERE nomeEspecialidade LIKE '%' + @especialidade + '%' 
	)

	SELECT * FROM Medicos ('psiquiatria')

--Criou uma fun��o para que retorne a idade do usu�rio a partir de uma determinada stored procedure
	CREATE PROCEDURE  idade
@idade VARCHAR(20)
    AS
 BEGIN
SELECT nomePaciente, DATEDIFF(YEAR,dataNasc,GETDATE())
    AS idade
  FROM USUARIO U
 INNER JOIN PACIENTE P
    ON U.idUsuario = P.idUsuario
 WHERE nomePaciente = @idade
   END
GO

idade 'Bruno'



	
	