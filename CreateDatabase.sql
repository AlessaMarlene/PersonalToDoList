USE master

IF EXISTS(select * from sys.databases where name='TasksDataBase')
DROP DATABASE TasksDataBase

CREATE DATABASE TasksDataBase

GO

USE TasksDataBase
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE Users(
	UserID int IDENTITY(1,1) NOT NULL,
	UserName varchar(10) NOT NULL,
	Password varchar(8) NOT NULL,
	CONSTRAINT pk_userid PRIMARY KEY(UserID)
)
GO

CREATE TABLE Tasks(
	TaskID int IDENTITY(1,1) NOT NULL,
	UserID int NOT NULL,
	Name varchar(15) NOT NULL,
	Description varchar(50),
	Completed bit NOT NULL,
	CONSTRAINT pk_taskid PRIMARY KEY(TaskID),
	CONSTRAINT fk_userid FOREIGN KEY(UserID)REFERENCES Users(UserID)
)
GO