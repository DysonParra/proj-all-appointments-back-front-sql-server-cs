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
    [EmployeeId]                        BIGINT                  NULL DEFAULT NULL,
    [From]                              DATETIME                NULL DEFAULT NULL,
    [To]                                DATETIME                NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Employee')
CREATE TABLE [dbo].[Employee] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [FirstName]                         VARCHAR(64)             NULL DEFAULT NULL,
    [LastName]                          VARCHAR(64)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Client')
CREATE TABLE [dbo].[Client] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [ClientName]                        VARCHAR(128)            NULL DEFAULT NULL,
    [ContactMobile]                     VARCHAR(128)            NULL DEFAULT NULL,
    [ContactMail]                       VARCHAR(128)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Service')
CREATE TABLE [dbo].[Service] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [ServiceName]                       VARCHAR(128)            NULL DEFAULT NULL,
    [Duration]                          BIGINT                  NULL DEFAULT NULL,
    [Price]                             DECIMAL(10, 2)          NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ServiceProvided')
CREATE TABLE [dbo].[ServiceProvided] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [AppointmentI]                      BIGINT                  NULL DEFAULT NULL,
    [ServiceId]                         BIGINT                  NULL DEFAULT NULL,
    [Price]                             DECIMAL(10, 2)          NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ServiceBooked')
CREATE TABLE [dbo].[ServiceBooked] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [AppointmentI]                      BIGINT                  NULL DEFAULT NULL,
    [ServiceId]                         BIGINT                  NULL DEFAULT NULL,
    [Price]                             DECIMAL(10, 2)          NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Appointment')
CREATE TABLE [dbo].[Appointment] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [DateCreated]                       DATETIME                NULL DEFAULT NULL,
    [EmployeeCreated]                   BIGINT                  NULL DEFAULT NULL,
    [ClientId]                          BIGINT                  NULL DEFAULT NULL,
    [EmployeeId]                        BIGINT                  NULL DEFAULT NULL,
    [ClientName]                        VARCHAR(128)            NULL DEFAULT NULL,
    [ClientContact]                     VARCHAR(128)            NULL DEFAULT NULL,
    [StartTime]                         DATETIME                NULL DEFAULT NULL,
    [EndTimeExpected]                   DATETIME                NULL DEFAULT NULL,
    [EndTime]                           DATETIME                NULL DEFAULT NULL,
    [PriceExpected]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [PriceFull]                         DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Discount]                          DECIMAL(10, 2)          NULL DEFAULT NULL,
    [PriceFinal]                        DECIMAL(10, 2)          NULL DEFAULT NULL,
    [Canceled]                          BIT                     NULL DEFAULT NULL,
    [CancelationReason]                 TEXT                    NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Schedule]
    ADD CONSTRAINT [FkScheduleEmployeeId]
        FOREIGN KEY ([EmployeeId])
        REFERENCES [Employee] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [ServiceBooked]
    ADD CONSTRAINT [FkServiceBookedServiceId]
        FOREIGN KEY ([ServiceId])
        REFERENCES [Service] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkServiceBookedAppointmentI]
        FOREIGN KEY ([AppointmentI])
        REFERENCES [Appointment] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [ServiceProvided]
    ADD CONSTRAINT [FkServiceProvidedServiceId]
        FOREIGN KEY ([ServiceId])
        REFERENCES [Service] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkServiceProvidedAppointmentI]
        FOREIGN KEY ([AppointmentI])
        REFERENCES [Appointment] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Appointment]
    ADD CONSTRAINT [FkAppointmentEmployeeCreated]
        FOREIGN KEY ([EmployeeCreated])
        REFERENCES [Employee] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkAppointmentEmployeeId]
        FOREIGN KEY ([EmployeeId])
        REFERENCES [Employee] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkAppointmentClientId]
        FOREIGN KEY ([ClientId])
        REFERENCES [Client] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;
