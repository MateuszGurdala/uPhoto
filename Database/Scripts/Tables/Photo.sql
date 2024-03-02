CREATE TABLE Photo
(
    Id             BIGINT PRIMARY KEY IDENTITY (1, 1),
    AlbumId        BIGINT           NOT NULL,
    LocationId     BIGINT           NULL,
    MimeTypeId     TINYINT          NOT NULL,
    Title          NVARCHAR(MAX)    NOT NULL,
    SourceFileName VARCHAR(255)     NOT NULL UNIQUE,
    Source         VARBINARY        NOT NULL,
    PreviewSource  VARBINARY        NOT NULL,
    Size           INT              NOT NULL,
    Width          INT              NOT NULL,
    Height         INT              NOT NULL,
    DateTaken      DATETIME2        NOT NULL,
    IsFavorite     BIT              NOT NULL DEFAULT 0,
    CreatedOn      DATETIME2        NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_Photo_AlbumId FOREIGN KEY (AlbumId) REFERENCES Album (Id),
    CONSTRAINT FK_Photo_LocationId FOREIGN KEY (AlbumId) REFERENCES GeographicalLocation (Id),
    CONSTRAINT FK_Photo_MimeTypeId FOREIGN KEY (MimeTypeId) REFERENCES MimeType (Id),
    CONSTRAINT FK_Photo_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES UserAccount (Id)
)
