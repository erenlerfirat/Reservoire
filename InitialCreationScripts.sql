CREATE SCHEMA app
GO

CREATE TABLE [app].[User] (
    Id Int NOT NULL  PRIMARY KEY IDENTITY(1,1),	
	FirstName varchar(100) NOT NULL,
    LastName varchar(100) NOT NULL,
	Email varchar(100),
	PasswordHash varchar(250),
	Phone varchar(50),
	FailedTryCount SmallInt,
	CreatedOn DateTime,
	UpdatedOn DateTime,
	IsDeleted Bit NOT NULL
);

CREATE TABLE [app].[UserRole] (
    Id Int NOT NULL PRIMARY KEY IDENTITY(1,1),
    RoleType SmallInt NOT NULL ,
    UserId Int NOT NULL,
	CreatedOn DateTime,
	UpdatedOn DateTime,
	IsDeleted Bit NOT NULL
);

CREATE TABLE [app].[UserAddress] (
    Id Int NOT NULL PRIMARY KEY IDENTITY(1,1),
    UserId Int NOT NULL,
	Description nvarchar(250),
	Country varchar(50),
	City varchar(50),
	District varchar(50),
	Street varchar(50),
	PostalCode Int,
	CreatedOn DateTime,
	UpdatedOn DateTime,
	IsDeleted Bit NOT NULL
);

CREATE TABLE [app].[Reservation] (
    Id Int NOT NULL PRIMARY KEY IDENTITY(1,1),
    UserId Int NOT NULL,
	BusinessOwnerUserId Int NOT NULL,
	Description nvarchar(250),
	Status SmallInt,
	ReservationDate DateTime,
	CreatedOn DateTime,
	UpdatedOn DateTime,
	IsDeleted Bit NOT NULL
);