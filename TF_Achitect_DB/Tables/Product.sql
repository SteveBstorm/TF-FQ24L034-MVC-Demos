﻿CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	Price DECIMAL(10,2) NOT NULL,
	Quantity INT NOT NULL
)
