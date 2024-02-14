-- Tabla Prestamo con los siguientes campos:
--  i. Numero Prestamo
--  ii. Tipo Prestamo
--  iii. Id Cliente
--  iv. Fecha de Inicio
--  v. Fecha de Fin
--  vi. Monto Solicitado
--  vii. Moneda
--  viii. Monto Aprobado
--  ix. Plazo de financiamiento
--  x. Estado
USE Test;

CREATE TABLE test.Loan (
    LoanId BIGINT IDENTITY(1,1) PRIMARY KEY,
    LoanType NVARCHAR(20) NOT NULL,
    CustomerId BIGINT FOREIGN KEY REFERENCES test.Customer(CustomerId) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    RequestedAmount DECIMAL(18,2) NOT NULL,
    CurrencyId BIGINT FOREIGN KEY REFERENCES test.Currency(CurrencyId) NOT NULL,
    ApprovedAmount DECIMAL(18,2) NOT NULL,
    FinancingTerm INT NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active',
    CreatedAt DATETIME DEFAULT GETDATE(),
    ModifiedAt DATETIME DEFAULT NULL,
    DeletedAt DATETIME DEFAULT NULL
);

CREATE INDEX idx_loanNumber ON test.Loan(LoanId);
