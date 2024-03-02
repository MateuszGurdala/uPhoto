CREATE TABLE UserAccount
(
    Id            UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    AccountTypeId TINYINT       NOT NULL,
    Email         VARCHAR(255)  NOT NULL UNIQUE,
    RegisteredOn  DATETIME2     NOT NULL       DEFAULT GETDATE(),
    LastSeenOn    DATETIME2     NOT NULL       DEFAULT GETDATE(),
    Name          NVARCHAR(MAX) NULL,
    Surname       NVARCHAR(MAX) NULL,
    CONSTRAINT FK_AccountTypeId FOREIGN KEY (AccountTypeId) REFERENCES AccountType (Id)
)
