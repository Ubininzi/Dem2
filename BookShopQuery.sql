USE MASTER
DROP DATABASE IF EXISTS BookShop
CREATE DATABASE BookShop

USE BookShop

CREATE TABLE PRODUCT(
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name_ NVARCHAR(50) NOT NULL,
	Author NVARCHAR(50) NOT NULL,
	Price MONEY,
	Desciption NVARCHAR(100),
	PathToImage NVARCHAR(100),
)

INSERT PRODUCT
VALUES	('1984','ORWELL',2000,'ABOBA','C:\\Users\\������\\Desktop\\wallpapers\\_F7dP5upuP4.jpg'),
		('HarryPotter','Rowling',1000,'ABO','ABO')