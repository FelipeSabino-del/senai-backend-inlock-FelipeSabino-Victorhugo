					-------DML--------
USE InLock_Games_Tarde

INSERT INTO Usuarios (Email,Senha, IdTipoUsuario)
VALUES	('admin@admin.com','admin','1'),
		('cliente@cliente.com','cliente','2')

INSERT INTO TiposUsuarios (Titulo)
VALUES	('ADMINISTRADOR'),
		('CLIENTE')

INSERT INTO Estudios (NomeEstudio)
VALUES	('Blizzard'),
		('Rockstar Studios'),
		('Square Enix')

INSERT INTO Jogos (NomeJogo, DataLancamento,Descricao,IdEstudio,Valor)
VALUES	('Diablo 3',
		'15/05/2012',
		'� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.',
		'1',
		'99.00'
		),
		
		('Red Dead Redemption II',
		'26/10/2018',
		'Jogo eletr�nico de a��o-aventura western',
		'2',
		'120')
