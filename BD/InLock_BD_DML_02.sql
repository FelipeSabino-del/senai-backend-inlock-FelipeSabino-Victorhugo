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
		'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.',
		'1',
		'99.00'
		),
		
		('Red Dead Redemption II',
		'26/10/2018',
		'Jogo eletrônico de ação-aventura western',
		'2',
		'120')
