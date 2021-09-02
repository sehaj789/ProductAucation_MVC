-- Script Date: 1/09/2021 11:46 pm  - ErikEJ.SqlCeScripting version 3.5.2.90
-- Database information:
-- Database: C:\Users\atind\source\repos\ProductAucation_MVC\Bid.db
-- ServerVersion: 3.35.5
-- DatabaseSize: 44 KB
-- Created: 31/08/2021 6:40 pm

-- User Table information:
-- Number of tables: 5
-- __EFMigrationsHistory: -1 row(s)
-- Brand: -1 row(s)
-- Place_Bid: -1 row(s)
-- Player: -1 row(s)
-- Product: -1 row(s)

SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [Player] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Name] text NOT NULL
, [Country] text NULL
, [Field] text NULL
);
CREATE TABLE [Brand] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Brand_Name] text NOT NULL
, [Description] text NULL
);
CREATE TABLE [Product] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Name] text NOT NULL
, [Brandid] bigint NOT NULL
, [Playerid] bigint NOT NULL
, CONSTRAINT [FK_Product_0_0] FOREIGN KEY ([Playerid]) REFERENCES [Player] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
, CONSTRAINT [FK_Product_1_0] FOREIGN KEY ([Brandid]) REFERENCES [Brand] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
);
CREATE TABLE [Place_Bid] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Your_Name] text NULL
, [Email] text NULL
, [Productid] bigint NOT NULL
, [Place_a_Bid] text NOT NULL
, CONSTRAINT [FK_Place_Bid_0_0] FOREIGN KEY ([Productid]) REFERENCES [Product] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
);
CREATE TABLE [__EFMigrationsHistory] (
  [MigrationId] text NOT NULL
, [ProductVersion] text NOT NULL
, CONSTRAINT [sqlite_autoindex___EFMigrationsHistory_1] PRIMARY KEY ([MigrationId])
);
INSERT INTO [Player] ([Id],[Name],[Country],[Field]) VALUES (
1,' Lionel Messi','Spanish','Footballer');
INSERT INTO [Player] ([Id],[Name],[Country],[Field]) VALUES (
2,'Cristiano Ronaldo','Potugal','Football');
INSERT INTO [Player] ([Id],[Name],[Country],[Field]) VALUES (
3,'Neymar','Brazil','Footballer');
INSERT INTO [Player] ([Id],[Name],[Country],[Field]) VALUES (
4,'Virat Kohli','India','Cricket');
INSERT INTO [Brand] ([Id],[Brand_Name],[Description]) VALUES (
1,'Nike','Nike t-shirts ');
INSERT INTO [Brand] ([Id],[Brand_Name],[Description]) VALUES (
2,'Jordan','Jordan branded cloths');
INSERT INTO [Brand] ([Id],[Brand_Name],[Description]) VALUES (
3,'Puma','Hoddies');
INSERT INTO [Product] ([Id],[Name],[Brandid],[Playerid]) VALUES (
1,'Nike T-shirt',1,2);
INSERT INTO [Product] ([Id],[Name],[Brandid],[Playerid]) VALUES (
2,'Shoes',2,3);
INSERT INTO [Place_Bid] ([Id],[Your_Name],[Email],[Productid],[Place_a_Bid]) VALUES (
1,'Atinder Singh','Atindersingh123@gmail.com',1,'67.0');
INSERT INTO [__EFMigrationsHistory] ([MigrationId],[ProductVersion]) VALUES (
'20210831064021_first','5.0.9');
CREATE INDEX [Product_IX_Product_Playerid] ON [Product] ([Playerid] ASC);
CREATE INDEX [Product_IX_Product_Brandid] ON [Product] ([Brandid] ASC);
CREATE INDEX [Place_Bid_IX_Place_Bid_Productid] ON [Place_Bid] ([Productid] ASC);
CREATE TRIGGER [fki_Product_Playerid_Player_Id] BEFORE Insert ON [Product] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table Product violates foreign key constraint FK_Product_0_0') WHERE (SELECT Id FROM Player WHERE  Id = NEW.Playerid) IS NULL; END;
CREATE TRIGGER [fku_Product_Playerid_Player_Id] BEFORE Update ON [Product] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table Product violates foreign key constraint FK_Product_0_0') WHERE (SELECT Id FROM Player WHERE  Id = NEW.Playerid) IS NULL; END;
CREATE TRIGGER [fki_Product_Brandid_Brand_Id] BEFORE Insert ON [Product] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table Product violates foreign key constraint FK_Product_1_0') WHERE (SELECT Id FROM Brand WHERE  Id = NEW.Brandid) IS NULL; END;
CREATE TRIGGER [fku_Product_Brandid_Brand_Id] BEFORE Update ON [Product] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table Product violates foreign key constraint FK_Product_1_0') WHERE (SELECT Id FROM Brand WHERE  Id = NEW.Brandid) IS NULL; END;
CREATE TRIGGER [fki_Place_Bid_Productid_Product_Id] BEFORE Insert ON [Place_Bid] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table Place_Bid violates foreign key constraint FK_Place_Bid_0_0') WHERE (SELECT Id FROM Product WHERE  Id = NEW.Productid) IS NULL; END;
CREATE TRIGGER [fku_Place_Bid_Productid_Product_Id] BEFORE Update ON [Place_Bid] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table Place_Bid violates foreign key constraint FK_Place_Bid_0_0') WHERE (SELECT Id FROM Product WHERE  Id = NEW.Productid) IS NULL; END;
COMMIT;

