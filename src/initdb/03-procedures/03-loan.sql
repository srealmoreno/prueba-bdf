USE Test;
GO

-- Crear Préstamo
CREATE PROCEDURE test.spCreateLoan
    @loanType NVARCHAR(20),
    @customerId BIGINT,
    @startDate DATE,
    @endDate DATE,
    @requestedAmount DECIMAL(18,2),
    @currencyCode NVARCHAR(3),
    @approvedAmount DECIMAL(18,2),
    @financingTerm INT
AS
BEGIN
    -- 1. Get currency id from procedure
    DECLARE @currencyId BIGINT;
    EXEC @currencyId = spgetCurrency @code = @currencyCode;

    -- 3. Create loan
    INSERT INTO test.Loan (loanType, customerId, startDate, endDate, requestedAmount, currencyId, approvedAmount, financingTerm)
    VALUES (@loanType, @customerId, @startDate, @endDate, @requestedAmount, @currencyId, @approvedAmount, @financingTerm);
END
GO

-- Obtener Préstamos
CREATE PROCEDURE test.spGetLoans
AS
BEGIN
    SELECT
        *
    FROM
        Loan l
    JOIN
        State s1 ON l.stateId = s1.stateId
    JOIN
        Currency c ON l.currencyId = c.currencyId
    WHERE
        l.deletedAt IS NULL;
END
GO

-- Obtener Préstamo por Id
CREATE PROCEDURE test.spGetLoanById
    @loanId BIGINT
AS
BEGIN
    SELECT
        *
    FROM
        Loan l
    JOIN
        State s1 ON l.stateId = s1.stateId
    JOIN
        Currency c ON l.currencyId = c.currencyId
    WHERE
        l.loanId = @loanId;
END
GO

-- Actualizar Préstamo
CREATE PROCEDURE test.spUpdateLoan
    @loanId BIGINT,
    @loanType NVARCHAR(20),
    @startDate DATE,
    @endDate DATE,
    @requestedAmount DECIMAL(18,2),
    @currencyCode NVARCHAR(3),
    @approvedAmount DECIMAL(18,2),
    @financingTerm INT,
    @status NVARCHAR(20)
AS
BEGIN
    -- 1. Get currency id from procedure
    DECLARE @currencyId BIGINT;
    EXEC @currencyId = spgetCurrency @code = @currencyCode;

    UPDATE Loan
    SET loanType = @loanType,
        startDate = @startDate,
        endDate = @endDate,
        requestedAmount = @requestedAmount,
        currencyId = @currencyId,
        approvedAmount = @approvedAmount,
        financingTerm = @financingTerm,
        status = @status,
        modifiedAt = GETDATE()
    WHERE loanId = @loanId;
END
GO

-- Eliminar Préstamo
CREATE PROCEDURE test.spDeleteLoan
    @loanId BIGINT
AS
BEGIN
    UPDATE Loan
    SET status = 'DELETED',
        deletedAt = GETDATE()
    WHERE loanId = @loanId;
END
GO
