

CREATE DATABASE pagos;
-- pagos.dbo.Orders definition

CREATE TABLE pagos.dbo.Orders (
	Id int IDENTITY(1,1) NOT NULL,
	CreatedDate datetime2 DEFAULT getutcdate() NOT NULL,
	UserId int NOT NULL,
	TotalAmount decimal(18,2) NOT NULL,
	CONSTRAINT PK_Orders PRIMARY KEY (Id)
);


-- pagos.dbo.OrderDetail definition

CREATE TABLE pagos.dbo.OrderDetail (
	Id int IDENTITY(1,1) NOT NULL,
	CreatedDate datetime2 DEFAULT getutcdate() NOT NULL,
	ProductId int NOT NULL,
	Price decimal(18,2) NOT NULL,
	OrderId int NOT NULL,
	CONSTRAINT PK_OrderDetail PRIMARY KEY (Id),
	CONSTRAINT FK_OrderDetail_Orders_OrderId FOREIGN KEY (OrderId) REFERENCES pagos.dbo.Orders(Id) ON DELETE CASCADE
);

-- pagos.dbo.ShipmentOrders definition


CREATE TABLE pagos.dbo.ShipmentOrders (
	Id int IDENTITY(1,1) NOT NULL,
	CreatedDate datetime2 DEFAULT getutcdate() NOT NULL,
	ShippingAddress nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	OrderId int NOT NULL,
	CONSTRAINT PK_ShipmentOrders PRIMARY KEY (Id),
	CONSTRAINT FK_ShipmentOrders_Orders_OrderId FOREIGN KEY (OrderId) REFERENCES pagos.dbo.Orders(Id) ON DELETE CASCADE
);

CREATE TABLE pagos.dbo.[__EFMigrationsHistory] (
	MigrationId nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProductVersion nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
);