
-- Tabla Direccion con los siguientes campos:
--  i. Id Direccion
--  ii. Descripcion
USE Test;

CREATE TABLE test.Address (
    AddressId BIGINT IDENTITY(1,1) PRIMARY KEY,
    CustomerId BIGINT FOREIGN KEY REFERENCES test.Customer(CustomerId) NOT NULL,
    Country NVARCHAR(100) NOT NULL,
    State NVARCHAR(100) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    Neighborhood NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active',
    IsPrimary BIT DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedAt DATETIME DEFAULT NULL,
    DeletedAt DATETIME DEFAULT NULL
);

CREATE INDEX idx_addressId ON test.Address(AddressId);
