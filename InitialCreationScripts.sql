CREATE SCHEMA app
GO

CREATE TABLE [app].[User] (
    Id int NOT NULL PRIMARY KEY,	
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
    Id int NOT NULL PRIMARY KEY,
    RoleType smallint NOT NULL ,
    UserId int NOT NULL,
	CreatedOn DateTime,
	UpdatedOn DateTime
);