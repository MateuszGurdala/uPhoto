CREATE TABLE GeographicalLocationType
(
    Id   TINYINT PRIMARY KEY IDENTITY (1, 1),
    Type VARCHAR(10) NOT NULL UNIQUE
)