use master
go

if exists(select *  from sysdatabases where name = 'BDPFPABIOS2023')
begin
	drop database BDPFPABIOS2023
end
go

create database BDPFPABIOS2023
go

use BDPFPABIOS2023
go

-- Tablas
create table Administrador
(
	nombreUsuario varchar(20),
	nombreCompleto varchar(50) not null,
	passUsuario varchar(20) not null,
	
	primary key(nombreUsuario)
)
go

create table Juego
(
	codigoJuego int identity(1,1),
	fechaCreacion datetime default getdate(),
	dificultad varchar(10) check(dificultad in ('FACIL', 'MEDIO', 'DIFICIL')),
	usuarioAdministradorJuego varchar(20) not null foreign key references Administrador(nombreUsuario),

	primary key(codigoJuego)
)
go

create table Jugada
(
	codigoJugada int identity(1,1),
	fechaHoraJugada datetime default getdate(),
	jugador varchar(20),
	puntaje int,
	codigoJuego int foreign key references Juego(codigoJuego),

	primary key(codigoJugada)
)
go

create table Categoria
(
	codigoCategoria varchar(4) check(codigoCategoria like '[A-Z][A-Z][A-Z][A-Z]'),
	nombre varchar(20),

	primary key(codigoCategoria)
)
go

create table Pregunta
(
	codigoPregunta varchar(5) check(codigoPregunta like '[A-Z0-9][A-Z0-9][A-Z0-9][A-Z0-9][A-Z0-9]'),
	puntaje int check(puntaje between 1 and 10),
	textoPregunta varchar(50),
	respuestaCorrecta int check(respuestaCorrecta in (1, 2, 3)),
	respuestaUno varchar(50),
	respuestaDos varchar(50),
	respuestaTres varchar(50),
	codigoCategoriaPregunta varchar(4) not null foreign key references Categoria(codigoCategoria),

	primary key(codigoPregunta)
)
go

create table JuegoTienePregunta
(
	codigoJuego int not null foreign key references Juego(codigoJuego),
	codigoPregunta varchar(5) not null foreign key references Pregunta(codigoPregunta),

	primary key(codigoJuego, codigoPregunta)
)
go

--Procedimientos almacenados
create procedure AltaAdministrador
@nombreUsuario varchar(20),
@nombreCompleto varchar(50),
@passUsuario varchar(20)
as
begin
	if exists(select * from Administrador where nombreUsuario = @nombreUsuario)
		return -1
	
	insert Administrador(nombreUsuario, nombreCompleto, passUsuario) 
	values(@nombreUsuario, @nombreCompleto, @passUsuario)

	if @@error = 0
		return 1
	else 
		return -2
end
go

create procedure LoginAdministrador
@nombreUsuario varchar(20),
@passUsuario varchar(20)
as
begin

	select * from Administrador where nombreUsuario = @nombreUsuario and passUsuario = @passUsuario

end
go

create procedure AltaCategoria
@codigoCategoria varchar(4),
@nombre varchar(20)
as
begin
	if exists(select * from Categoria where codigoCategoria = @codigoCategoria)
		return -1
	
	insert Categoria(codigoCategoria, nombre) 
	values(@codigoCategoria, @nombre)

	if @@error = 0
		return 1
	else 
		return -2
end
go

create procedure BuscarCategoria
@codigoCategoria varchar(4)
as
begin

	select * from Categoria where codigoCategoria = @codigoCategoria 

end
go

create procedure ModificarCategoria
@codigoCategoria varchar(4),
@nombre varchar(20)
as 
begin 
	if not exists(select * from Categoria where codigoCategoria = @codigoCategoria)
		return -1

	update Categoria
	set nombre = @nombre 
	where codigoCategoria = @codigoCategoria

	if @@error = 0 
		return 1
	else
		return -2
end
go

create procedure BajaCategoria
@codigoCategoria varchar(4)
as
begin
	if not exists(select * from Categoria where codigoCategoria = @codigoCategoria)
		return -1
	
	if exists (select * from Pregunta where codigoCategoriaPregunta = @codigoCategoria)
		return -2
	
	delete Categoria
	where codigoCategoria = @codigoCategoria
	
	if @@error = 0
		return 1
	else
		return -3
end
go

create procedure AltaPregunta
@codigoPregunta varchar(5),
@puntaje int,
@textoPregunta varchar(50),
@respuestaCorrecta int,
@respuestaUno varchar(50),
@respuestaDos varchar(50),
@respuestaTres varchar(50),
@codigoCategoriaPregunta varchar(4)
as
begin
	if exists(select * from Pregunta where codigoPregunta = @codigoPregunta)
		return -1
	
	if not exists(select * from Categoria where codigoCategoria = @codigoCategoriaPregunta)
		return -2


	insert Pregunta(codigoPregunta, puntaje, textoPregunta, respuestaCorrecta, respuestaUno, respuestaDos, respuestaTres, codigoCategoriaPregunta) 
	values(@codigoPregunta, @puntaje, @textoPregunta, @respuestaCorrecta, @respuestaUno, @respuestaDos, @respuestaTres, @codigoCategoriaPregunta)

	if @@error = 0
		return 1
	else 
		return -2

		
end
go

create procedure AltaJuego
@dificultad varchar(10),
@usuarioAdministradorJuego varchar(20)
as
begin
	if not exists(select * from Administrador where nombreUsuario = @usuarioAdministradorJuego)
		return -1

	insert Juego(dificultad, usuarioAdministradorJuego)
	values(@dificultad, @usuarioAdministradorJuego)

	if @@error = 0
		return 1
	else
		return -2
end
go

create procedure AsociarPreguntaJuego
@codigoJuego int,
@codigoPregunta varchar(5)
as
begin 
	if not exists(select * from Juego where codigoJuego = @codigoJuego)
		return -1
	
	if not exists(select * from Pregunta where codigoPregunta = @codigoPregunta)
		return -2

	if exists(select * from JuegoTienePregunta where codigoJuego = @codigoJuego and codigoPregunta = @codigoPregunta)
		return -3

	insert JuegoTienePregunta(codigoJuego, codigoPregunta)
	values (@codigoJuego, @codigoPregunta)

	if @@error = 0
		return 1
	else 
		return -4
end
go

create procedure DesasociarPreguntaJuego
@codigoJuego int,
@codigoPregunta varchar(5)
as
begin 

	if exists(select * from JuegoTienePregunta where codigoJuego = @codigoJuego and codigoPregunta = @codigoPregunta)

		delete from JuegoTienePregunta
		where codigoJuego = @codigoJuego and codigoPregunta = @codigoPregunta

	if @@error = 0
		return 1
	else 
		return -1
end
go

--AlmacenarJugada (fechaHora [generado automaticamente al momento de terminar el juego]
--                 nombreJugador, juegoJugado, puntajeFinalObtenido [Session])
create procedure AlmacenarJugada
@jugador varchar(20),
@codigoJuego int,
@puntajeFinal int
as
begin
	if not exists (select * from Juego where codigoJuego = @codigoJuego)
		return -1
	
	insert Jugada(jugador, codigoJuego, puntaje)
	values(@jugador, @codigoJuego, @puntajeFinal)

	if @@error = 0
		return 1
	else
		return -2
end
go

create procedure ListarJuegos
as
begin
	select * from Juego
end 
go

create procedure ListarJugadas
as
begin
	select * from Jugada order by fechaHoraJugada
end
go

create procedure ListarAdministradores
as
begin
	select * from Administrador
end
go

create procedure ListarCategorias
as
begin
	select * from Categoria
end
go

create procedure ListarPreguntas
as
begin
	select * from Pregunta
end
go

create procedure BuscarPregunta
@codigoPregunta varchar(5)
as
begin
	select * from Pregunta where codigoPregunta = @CodigoPregunta
end
go

--Datos de prueba
exec AltaAdministrador 'admin', 'Administrador', 'admin'
exec AltaCategoria 'HIST', 'Historia'
exec AltaCategoria 'MATH', 'Matematicas'
exec AltaCategoria 'CINE', 'Cine'
exec AltaCategoria 'MUSI', 'Musica'
exec AltaCategoria 'ARTE', 'Arte'
exec AltaCategoria 'GAME', 'Juegos'
exec AltaCategoria 'DEPO', 'Deportes'

exec ModificarCategoria 'MATH', 'Matematica'
exec BajaCategoria 'MUSI'

exec AltaPregunta 'aZ8x7' ,10 , 'Quien descrubrio America?', 3, 'Luis Suarez', 'Cristobal Colon', 'Chino recoba', 'HIST'
exec AltaPregunta 'ak8ui' ,10 , 'Cuanto es 2 + 2?', 1, '4', '8', '0', 'MATH'

exec AltaJuego 'MEDIO', 'admin'
exec AltaJuego 'FACIL', 'admin'
exec AltaJuego 'DIFICIL', 'admin'

exec AsociarPreguntaJuego 1, 'aZ8x7'
exec AsociarPreguntaJuego 2, 'aZ8x7'
exec AsociarPreguntaJuego 1, 'ak8ui'

exec DesasociarPreguntaJuego 2, 'aZ8x7'

exec AlmacenarJugada 'Christiams Sena', 2, 245
exec AlmacenarJugada 'Cristian Capretti', 3, 35
exec AlmacenarJugada 'Paula Sanchez', 1, 1245

--Ejecucion de listados
--exec ListarAdministradores
--exec ListarCategorias
--exec ListarPreguntas
--exec ListarJuegos
--exec ListarJugadas
