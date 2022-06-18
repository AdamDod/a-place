IF OBJECT_ID('CELLS') IS NOT NULL
DROP TABLE CELLS
GO

CREATE TABLE CELLS
(
    CellID INT PRIMARY KEY,
    Colour [NVARCHAR] (10),
);
GO


SELECT * FROM CELLS;

Select * from sysdatabases

using master