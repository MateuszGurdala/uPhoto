BEGIN
    SET NOCOUNT ON;

    INSERT INTO MimeType (Name) VALUES ('image/jpeg');
    INSERT INTO MimeType (Name) VALUES ('image/jpg');
    INSERT INTO MimeType (Name) VALUES ('image/png');

    SET NOCOUNT OFF ;
END