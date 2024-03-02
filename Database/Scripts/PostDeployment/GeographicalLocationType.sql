BEGIN
    SET NOCOUNT ON;

    INSERT INTO GeographicalLocationType (Type) VALUES ('Area');
    INSERT INTO GeographicalLocationType (Type) VALUES ('Country');
    INSERT INTO GeographicalLocationType (Type) VALUES ('City');
    INSERT INTO GeographicalLocationType (Type) VALUES ('Street');
    INSERT INTO GeographicalLocationType (Type) VALUES ('Place');

    SET NOCOUNT OFF ;
END