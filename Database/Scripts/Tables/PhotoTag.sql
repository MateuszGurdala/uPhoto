CREATE TABLE PhotoTag
(
    PhotoId   BIGINT           NOT NULL,
    TagId     BIGINT           NOT NULL,
    CreatedOn DATETIME2        NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT PK_PhotoTag PRIMARY KEY (PhotoId, TagId),
    CONSTRAINT FK_PhotoTag_PhotoId FOREIGN KEY (PhotoId) REFERENCES Photo (Id),
    CONSTRAINT FK_PhotoTag_TagId FOREIGN KEY (PhotoId) REFERENCES Tag (Id),
    CONSTRAINT FK_PhotoTag_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES UserAccount (Id),
)
