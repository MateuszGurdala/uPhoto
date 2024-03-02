CREATE TABLE AlbumAccessPrivilege
(
    UserAccountId UNIQUEIDENTIFIER NOT NULL,
    AlbumId       BIGINT           NOT NULL,
    PrivilegeId   TINYINT          NOT NULL,
    CONSTRAINT PK_AlbumAccessPrivilege PRIMARY KEY (UserAccountId, AlbumId, PrivilegeId),
    CONSTRAINT FK_AlbumAccessPrivilege_PrivilegeId FOREIGN KEY (PrivilegeId) REFERENCES Privilege (Id),
    CONSTRAINT FK_AlbumAccessPrivilege_UserAccountId_AlbumId FOREIGN KEY (UserAccountId, AlbumId) REFERENCES UserAlbumAccess (UserAccountId, AlbumId),
)
