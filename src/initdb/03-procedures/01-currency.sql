USE Test;
GO

-- Crear Moneda
CREATE PROCEDURE test.spCreateCurrency
    @Code NVARCHAR(5),
    @Symbol NVARCHAR(5),
    @Description NVARCHAR(50)
AS
BEGIN
    INSERT INTO test.Currency (Code, Symbol, Description)
    VALUES (@Code, @Symbol, @Description);
    SELECT SCOPE_IDENTITY();
    RETURN SCOPE_IDENTITY();
END
GO

-- Obtener Moneda por código
-- Error if currencyCode is not found
CREATE PROCEDURE test.spGetCurrency
    @code NVARCHAR(3)
AS
BEGIN
    DECLARE @currencyId BIGINT = (SELECT currencyId FROM test.Currency WHERE code = @code);
    IF @currencyId IS NULL
    BEGIN
        RAISERROR('Failed on getting currency. Currency not found', 16, 1);
        RETURN;
    END;
    RETURN @currencyId;
END
GO
