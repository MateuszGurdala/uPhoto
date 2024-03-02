BEGIN
    SET NOCOUNT ON;

    DECLARE @AdminAccountTypeId TINYINT;
    SELECT @AdminAccountTypeId = Id FROM AccountType WHERE Type = 'Admin';

    INSERT INTO UserAccount (AccountTypeId, Email) VALUES (@AdminAccountTypeId, 'admin.email@gmail.com');

    SET NOCOUNT OFF;
END