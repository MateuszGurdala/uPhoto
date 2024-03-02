CREATE TABLE UserAlbumAccess
(
    UserAccountId UNIQUEIDENTIFIER NOT NULL,
    AlbumId       BIGINT           NOT NULL,
    CreatedOn     DATETIME2        NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT PK_UserAlbumAccess PRIMARY KEY (UserAccountId, AlbumId),
    CONSTRAINT FK_UserAlbumAccess_UserAccountId FOREIGN KEY (UserAccountId) REFERENCES UserAccount (Id),
    CONSTRAINT FK_UserAlbumAccess_AlbumId FOREIGN KEY (AlbumId) REFERENCES Album (Id),
    CONSTRAINT FK_UserAlbumAccess_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES UserAccount (Id),
)
