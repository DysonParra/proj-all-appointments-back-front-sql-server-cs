USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Appointments') DROP DATABASE [Appointments]
GO
CREATE DATABASE [Appointments];
GO
USE [Appointments];
GO

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Schedule')
CREATE TABLE [dbo].[Schedule] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [Employee_Id]                       BIGINT                  NULL DEFAULT NULL,
    [From]                              DATETIME                NULL DEFAULT NULL,
    [To]                                DATETIME                NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Employee')
CREATE TABLE [dbo].[Employee] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [First_Name]                        VARCHAR(64)             NULL DEFAULT NULL,
    [Last_Name]                         VARCHAR(64)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Client')
CREATE TABLE [dbo].[Client] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [Client_Name]                       VARCHAR(128)            NULL DEFAULT NULL,
    [Contact_Mobile]                    VARCHAR(128)            NULL DEFAULT NULL,
    [Contact_Mail]                      VARCHAR(128)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Service')
CREATE TABLE [dbo].[Service] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [Service_Name]                      VARCHAR(128)            NULL DEFAULT NULL,
    [Duration]                          BIGINT                  NULL DEFAULT NULL,
    [Price]                             DECIMAL(10, 2)          NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Service_Provided')
CREATE TABLE [dbo].[Service_Provided] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [Appointment_I]                     BIGINT                  NULL DEFAULT NULL,
    [Service_Id]                        BIGINT                  NULL DEFAULT NULL,
    [Price]                             DECIMAL(10, 2)          NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Service_Booked')
CREATE TABLE [dbo].[Service_Booked] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [Appointment_I]                     BIGINT                  NULL DEFAULT NULL,
    [Service_Id]                        BIGINT                  NULL DEFAULT NULL,
    [Price]                             DECIMAL(10, 2)          NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Appointment')
CREATE TABLE [dbo].[Appointment] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [Date_Created]                      DATETIME                NULL DEFAULT NULL,
    [Employee_Created]                  BIGINT                  NULL DEFAULT NULL,
    [Client_Id]                         BIGINT                  NULL DEFAULT NULL,
    [Employee_Id]                       BIGINT                  NULL DEFAULT NULL,
    [Client_Name]                       VARCHAR(128)            NULL DEFAULT NULL,
    [Client_Contact]                    VARCHAR(128)            NULL DEFAULT NULL,
    [Start_Time]                        DATETIME                NULL DEFAULT NULL,
    [End_Time_Expected]                 DATETIME                NULL DEFAULT NULL,
    [End_Time]                          DATETIME                NULL DEFAULT NULL,
    [Price_Expected]                    DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Price_Full]                        DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Discount]                          DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Price_Final]                       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Canceled]                          BIT                     NULL DEFAULT NULL,
    [Cancelation_Reason]                TEXT                    NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Schedule]
    ADD CONSTRAINT [Fk_Schedule_Employee_Id]
        FOREIGN KEY ([Employee_Id])
        REFERENCES [Employee] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Service_Booked]
    ADD CONSTRAINT [Fk_Service_Booked_Service_Id]
        FOREIGN KEY ([Service_Id])
        REFERENCES [Service] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Service_Booked_Appointment_I]
        FOREIGN KEY ([Appointment_I])
        REFERENCES [Appointment] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Service_Provided]
    ADD CONSTRAINT [Fk_Service_Provided_Service_Id]
        FOREIGN KEY ([Service_Id])
        REFERENCES [Service] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Service_Provided_Appointment_I]
        FOREIGN KEY ([Appointment_I])
        REFERENCES [Appointment] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Appointment]
    ADD CONSTRAINT [Fk_Appointment_Employee_Created]
        FOREIGN KEY ([Employee_Created])
        REFERENCES [Employee] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Appointment_Employee_Id]
        FOREIGN KEY ([Employee_Id])
        REFERENCES [Employee] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Appointment_Client_Id]
        FOREIGN KEY ([Client_Id])
        REFERENCES [Client] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;
