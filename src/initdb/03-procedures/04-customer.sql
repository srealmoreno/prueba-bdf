USE Test;
GO

-- Crear Cliente
CREATE PROCEDURE test.spCreateCustomer
    @idNumber NVARCHAR(20),
    @idType NVARCHAR(20),
    @firstName NVARCHAR(50),
    @secondName NVARCHAR(50),
    @firstLastName NVARCHAR(50),
    @secondLastName NVARCHAR(50),
    @address NVARCHAR(100)
AS
BEGIN
     -- 1. Create customer
    INSERT INTO test.Customer (idNumber, idType, firstName, secondName, firstLastName, secondLastName)
    VALUES (@idNumber, @idType, @firstName, @secondName, @firstLastName, @secondLastName);

    DECLARE @customerId BIGINT = SCOPE_IDENTITY();

    -- 2. Create address
    --DECLARE @addressId BIGINT;
    --EXEC @addressId = spCreateAddress @description = @address, @customerId = @customerId;

    SELECT @customerId
    RETURN @customerId;
END
GO

-- Obtener Clientes
CREATE PROCEDURE test.spGetCustomers
AS
BEGIN
    SELECT
        *
    FROM
        test.Customer c
    LEFT JOIN
        test.Address a ON c.customerId = a.customerId AND a.deletedAt IS NULL
    LEFT JOIN
        test.Loan l ON c.customerId = l.customerId AND l.deletedAt IS NULL
    WHERE
        c.deletedAt IS NULL;
END
GO

-- Obtener Cliente por Id
CREATE PROCEDURE test.spGetCustomerById
    @customerId BIGINT
AS
BEGIN
    SELECT
        *
    FROM
        test.Customer c
    LEFT JOIN
        test.Address a ON c.customerId = a.customerId AND a.deletedAt IS NULL
    LEFT JOIN
        test.Loan l ON c.customerId = l.customerId AND l.deletedAt IS NULL
    WHERE
        c.customerId = @customerId AND c.deletedAt IS NULL;
END
GO

-- Actualizar Cliente
CREATE PROCEDURE test.spUpdateCustomer
    @customerId BIGINT,
    @idNumber NVARCHAR(20),
    @idType NVARCHAR(20),
    @firstName NVARCHAR(50),
    @secondName NVARCHAR(50),
    @firstLastName NVARCHAR(50),
    @secondLastName NVARCHAR(50),
    @status NVARCHAR(20)
AS
BEGIN
    UPDATE test.Customer
    SET idNumber = @idNumber,
        idType = @idType,
        firstName = @firstName,
        secondName = @secondName,
        firstLastName = @firstLastName,
        secondLastName = @secondLastName,
        status = @status,
        modifiedAt = GETDATE()
    WHERE customerId = @customerId;
END
GO

-- Eliminar Cliente
CREATE PROCEDURE test.spDeleteCustomer
    @customerId BIGINT
AS
BEGIN
    -- Check if customer has loans active
    IF EXISTS (SELECT 1 FROM test.Loan WHERE customerId = @customerId AND deletedAt IS NULL)
    BEGIN
        RAISERROR('Failed on deleting customer. Customer has active loans', 16, 1);
        RETURN;
    END;

    UPDATE test.Customer
    SET status = 'DELETED',
        deletedAt = GETDATE()
    WHERE customerId = @customerId;
END
GO
