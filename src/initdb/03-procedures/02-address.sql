USE Test;
GO

-- Crear Dirección
CREATE PROCEDURE test.spCreateAddress
    @customerId BIGINT,
    @description NVARCHAR(100)
AS
BEGIN
    DECLARE @isPrimary BIT = 0;

    IF NOT EXISTS (SELECT * FROM test.Address WHERE customerId = @customerId)
    BEGIN
        SET @isPrimary = 1;
    END

    INSERT INTO test.Address (customerId, description, isPrimary)
    VALUES (@customerId, @description, @isPrimary);
    SELECT SCOPE_IDENTITY();
    RETURN SCOPE_IDENTITY();
END
GO

-- Obtener Direcciónes
CREATE PROCEDURE test.spGetAddresses
AS
BEGIN
    SELECT *
    FROM 
        Address a
    WHERE
        a.deletedAt IS NULL;
END
GO

-- Obtener Dirección por Id
CREATE PROCEDURE test.spGetAddressById
    @addressId BIGINT
AS
BEGIN
    SELECT *
    FROM 
        Address a
    WHERE
        a.addressId = @addressId
    AND
        a.deletedAt IS NULL;
END
GO

-- Obtener Dirección por Id cliente
CREATE PROCEDURE test.spGetAddressByCustomerId
    @customerId BIGINT
AS
BEGIN
    SELECT *
    FROM 
        Address a
    WHERE
        a.customerId = @customerId
    AND
        a.deletedAt IS NULL;
END
GO

-- Actualizar Dirección
CREATE PROCEDURE test.spUpdateAddress
    @addressId BIGINT,
    @description NVARCHAR(100),
    @status NVARCHAR(20),
    @isPrimary BIT
AS
BEGIN
    UPDATE Address
    SET description = @description,
        status = @status,
        isPrimary = @isPrimary,
        modifiedAt = GETDATE()
    WHERE addressId = @addressId;
END
GO

-- Eliminar Dirección
CREATE PROCEDURE test.spDeleteAddress
    @addressId BIGINT
AS
BEGIN
    UPDATE Address
    SET status = 'DELETED',
        deletedAt = GETDATE()
    WHERE addressId = @addressId;
END
GO
