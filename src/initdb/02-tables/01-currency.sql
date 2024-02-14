USE Test;

CREATE TABLE test.Currency (
    CurrencyId BIGINT IDENTITY(1,1) PRIMARY KEY,
    Code NVARCHAR(5) NOT NULL UNIQUE,
    Symbol NVARCHAR(5) NOT NULL,
    Description NVARCHAR(50) NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active',
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedAt DATETIME DEFAULT NULL,
    DeletedAt DATETIME DEFAULT NULL
);

CREATE INDEX idx_currencyId ON test.Currency(CurrencyId);
