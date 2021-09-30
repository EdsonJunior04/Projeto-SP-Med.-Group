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
	--Calculou a idade do usuário a partir da data de nascimento
	SELECT PACIENTE.nomePaciente,
	DATEDIFF (YEAR, dataNasc, GETDATE() ) Idade
	FROM PACIENTE
	GO


--12. Aplicar programação em banco de dados utilizando functions, stored procedures,
--triggers e eventos


--Criou uma função para retornar a quantidade de médicos de uma determinada especialidade
	CREATE FUNCTION  Medicos (@especialidade VARCHAR (70))
	RETURNS TABLE AS RETURN(
	SELECT @especialidade AS ESPECIALIZACAO,  COUNT(idEspecialidade)  [ Quantidade de Medicos]  FROM ESPECIALIDADE
	WHERE nomeEspecialidade LIKE '%' + @especialidade + '%' 
	)

	SELECT * FROM Medicos ('psiquiatria')

--Criou uma função para que retorne a idade do usuário a partir de uma determinada stored procedure
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



	
	