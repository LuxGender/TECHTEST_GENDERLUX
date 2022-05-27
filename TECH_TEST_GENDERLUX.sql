CREATE DATABASE TECH_TEST_GENDERLUX

USE TECH_TEST_GENDERLUX

CREATE TABLE DatosUsuario (
IdUsuario INT PRIMARY KEY IDENTITY NOT NULL,
Nombre VARCHAR(40) NOT NULL,
Correo VARCHAR(40) NOT NULL,
Departamento VARCHAR(40) NOT NULL,
);

select * from DatosUsuario
//
CREATE PROCEDURE DatosUsuario_All
As
SELECT IdUsuario, Nombre, Correo, Departamento FROM DatosUsuario
ORDER BY IdUsuario ASC

//procedimiento adds
create proc DatosUsuario_Add
@Nombre VARCHAR(40),
@Correo VARCHAR(40),
@Depto VARCHAR(40)
AS
INSERT INTO DatosUsuario(Nombre, Correo, Departamento)
VALUES (@Nombre, @Correo, @Depto)

//updates
create proc DatosUsuario_Update
@Id INT,
@Nombre VARCHAR(40),
@Correo VARCHAR(40),
@Depto VARCHAR(40)
AS
UPDATE DatosUsuario
SET
Nombre = @Nombre,
Correo = @Correo,
Departamento = @Depto
WHERE IdUsuario = @Id

//deletes
CREATE PROC DatosUsuario_Delete
@id int
AS
DELETE FROM DatosUsuario
WHERE IdUsuario = @id