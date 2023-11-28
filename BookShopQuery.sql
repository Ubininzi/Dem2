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
	Discount FLOAT,
	Stock INT,
	Desciption NVARCHAR(100),
	PathToImage NVARCHAR(100),
)
CREATE TABLE ROLES(
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ROLENAME NVARCHAR(50) NOT NULL
)

CREATE TABLE LOGINS(
	LOGIN_ NVARCHAR(50) NOT NULL PRIMARY KEY,
	PASSWORD_ NVARCHAR(50) NOT NULL,
	ROLE_ INT NOT NULL REFERENCES ROLES(ID)
)

INSERT PRODUCT
VALUES	('1984','ORWELL',2000,0.1,50,'ABOBA','D:\Users\ST307-07\Downloads\Among Us - Раскраска - 1.png'),
		('HarryPotter','Rowling',1984,0.15,1000,'ABO','D:\Users\ST307-07\Downloads\Among Us - Раскраска - 1.png')
INSERT ROLES
VALUES ('USER'),('MANAGER'),('ADMIN')

INSERT LOGINS
VALUES ('ABOBA','153855415',3),
('ABOB','153855415',1)