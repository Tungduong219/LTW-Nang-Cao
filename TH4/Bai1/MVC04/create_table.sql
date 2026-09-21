CREATE TABLE tblProducts (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(150) NOT NULL UNIQUE,
    ImageURL NVARCHAR(500) NOT NULL,
    ProductPrice DECIMAL(18, 2) NOT NULL CHECK (ProductPrice >= 0),
    Description NVARCHAR(MAX) NULL
);
