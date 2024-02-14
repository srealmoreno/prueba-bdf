USE Test;
GO

-- Cantidad de Prestamos por estado y moneda con monto mayo a 10,000 dólares
CREATE VIEW test.vwLoanStateCurrency AS
SELECT
    cu.code,
    cu.description,
    cu.symbol,
    l.status,
    COUNT(l.loanId) AS loanCount,
    SUM(l.approvedAmount) AS totalAmount
FROM
    test.Loan l
JOIN
    test.Currency cu ON l.currencyId = cu.currencyId AND cu.code = 'USD'
WHERE
    l.approvedAmount > 10000 AND l.deletedAt IS NULL
GROUP BY
    cu.code,
    cu.description,
    cu.symbol,
    l.status;
GO
