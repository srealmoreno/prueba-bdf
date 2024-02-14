-- Tabla Cliente con los siguientes campos:
--  i. Id
--  ii. Numero de Identificacion
--  iii. Tipo de Identificacion
--  iv. Primer Nombre
--  v. Segundo Nombre
--  vi. Primer Apellido
--  vii. Segundo Apellido
--  viii. Id Direccion
--  ix. Estado
USE Test;

CREATE TABLE test.Customer (
    CustomerId BIGINT IDENTITY(1,1) PRIMARY KEY,
    IdNumber NVARCHAR(20) NOT NULL,
    IdType NVARCHAR(20) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    SecondName NVARCHAR(50),
    FirstLastName NVARCHAR(50) NOT NULL,
    SecondLastName NVARCHAR(50),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active',
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedAt DATETIME DEFAULT NULL,
    DeletedAt DATETIME DEFAULT NULL
);

CREATE INDEX idx_customerId ON test.Customer(CustomerId);
