CREATE SCHEMA app
GO

CREATE TABLE [app].[User] (
    Id int NOT NULL  PRIMARY KEY IDENTITY(1,1),	
	FirstName varchar(50) NOT NULL,
    LastName varchar(50) NOT NULL,
	Email varchar(50),
	PasswordHash varchar(250),
	Phone varchar(50),
	UserRoleId int ,
	FailedTryCount smallint,
	CreatedOn DateTime,
	UpdatedOn DateTime
);
GO

CREATE TABLE [app].[UserRole] (
    Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
    RoleType smallint NOT NULL ,
    UserId int NOT NULL,
	CreatedOn DateTime,
	UpdatedOn DateTime
);

CREATE TABLE [app].[UserAddress] (
    Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
    UserId int NOT NULL,
	Description nvarchar(250),
	Country varchar(50),
	City varchar(50),
	District varchar(50),
	Street varchar(50),
	PostalCode smallint,
	CreatedOn DateTime,
	UpdatedOn DateTime
);