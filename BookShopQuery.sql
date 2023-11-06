USE MASTER
ALTER DATABASE BookShop SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE IF EXISTS BookShop
CREATE DATABASE BookShop

USE BookShop

CREATE TABLE PRODUCT(
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name_ NVARCHAR(50) NOT NULL,
	Author NVARCHAR(50) NOT NULL,
	Price MONEY,
	Stock INT,
	Desciption NVARCHAR(100),
	PathToImage NVARCHAR(100),
)

INSERT PRODUCT
VALUES	('1984','ORWELL',2000,50,'ABOBA','C:\\Users\\Максим\\Desktop\\wallpapers\\_F7dP5upuP4.jpg'),
		('HarryPotter','Rowling',1984,1000,'ABO','C:\\Users\\Максим\\Desktop\\wallpapers\\BumerTos1.jpg')