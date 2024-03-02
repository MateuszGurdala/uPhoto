CREATE TABLE GeographicalLocation
(
    Id             BIGINT PRIMARY KEY IDENTITY (1, 1),
    ParentId       BIGINT           NULL,
    LocationTypeId TINYINT          NOT NULL,
    Name           NVARCHAR(MAX)    NOT NULL,
    IsPublic       BIT              NOT NULL DEFAULT 0,
    Latitude       INT              NULL,
    Longitude      INT              NULL,
    Description    NVARCHAR(MAX)    NULL,
    CreatedOn      DATETIME2        NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_GeographicalLocation_ParentId FOREIGN KEY (ParentId) REFERENCES GeographicalLocation (Id),
    CONSTRAINT FK_GeographicalLocation_LocationTypeId FOREIGN KEY (LocationTypeId) REFERENCES GeographicalLocationType (Id),
    CONSTRAINT FK_GeographicalLocation_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES UserAccount (Id)
)