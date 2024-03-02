BEGIN
    SET NOCOUNT ON;

    INSERT INTO AccountType (Type) VALUES ('Admin');
    INSERT INTO AccountType (Type) VALUES ('User');
    INSERT INTO AccountType (Type) VALUES ('Guest');

    SET NOCOUNT OFF ;
END