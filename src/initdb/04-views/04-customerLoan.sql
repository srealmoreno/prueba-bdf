USE Test;
GO
-- 4. Elaborar Consulta que genere los siguientes resultados
--  Listado de Clientes con sus direcciones y prestamos asociados, cuyos prestamos
--  estén activos y el plazo de financiamiento sea mayo a 36 meses
CREATE VIEW test.vwCustomerLoan AS
SELECT 
    c.customerId, 
    c.idNumber, 
    c.idType, 
    c.firstName, 
    c.secondName, 
    c.firstLastName, 
    c.secondLastName, 
    a.description, 
    l.loanId, 
    l.loanType, 
    l.startDate, 
    l.endDate, 
    l.requestedAmount, 
    l.approvedAmount, 
    l.financingTerm
FROM
    test.Customer c
JOIN
    test.Address a ON c.customerId = a.customerId AND a.deletedAt IS NULL
JOIN
    test.Loan l ON c.customerId = l.customerId AND l.deletedAt IS NULL
WHERE
    l.status = 'ACTIVE' AND l.financingTerm > 36;
GO