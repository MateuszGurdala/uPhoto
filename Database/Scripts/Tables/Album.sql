CREATE TABLE Album
(
    Id          BIGINT PRIMARY KEY IDENTITY (1, 1),
    Name        NVARCHAR(MAX)    NOT NULL,
    IsShared    BIT              NOT NULL DEFAULT 0,
    Description NVARCHAR(MAX)    NULL,
    CreatedOn   DATETIME2        NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES UserAccount (Id)
)