				-------DQL--------
USE InLock_Games_Tarde;

SELECT * FROM Usuarios
SELECT * FROM TiposUsuarios
SELECT * FROM Jogos
SELECT * FROM Estudios

--Listar todos os jogos e seus respectivos estúdios; 
SELECT Jogos.NomeJogo, Estudios.NomeEstudio FROM Jogos
INNER JOIN Estudios ON Estudios.IdEstudio = Jogos.IdEstudio

--Buscar e trazer na lista todos os estúdios com os respectivos jogos.
--Obs.: Listar todos os estúdios mesmo que eles não contenham nenhum jogo de referência;
SELECT Jogos.NomeJogo, Estudios.NomeEstudio FROM Jogos
RIGHT JOIN Estudios ON Estudios.IdEstudio = Jogos.IdEstudio

--Buscar um usuário por email e senha;
SELECT IdUsuario, Email, Senha FROM Usuarios WHERE Email = 'admin@admin.com' AND Senha='admin';

--Buscar um jogo por IdJogo; 
SELECT IdJogo,NomeJogo,Descricao,DataLancamento,Valor,IdEstudio	FROM Jogos WHERE IdJogo = 1;

--Buscar um estúdio por IdEstudio; 
SELECT IdEstudio,NomeEstudio FROM Estudios WHERE IdEstudio = 2;

SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor,Estudios.NomeEstudio FROM Jogos INNER JOIN Estudios ON Estudios.IdEstudio = Jogos.IdEstudio;
