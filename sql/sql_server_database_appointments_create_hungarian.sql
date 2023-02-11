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
    [IntId]                             BIGINT              NOT NULL IDENTITY,
    [IntEmployeeId]                     BIGINT                  NULL DEFAULT NULL,
    [DtFrom]                            DATETIME                NULL DEFAULT NULL,
    [DtTo]                              DATETIME                NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Employee')
CREATE TABLE [dbo].[Employee] (
    [IntId]                             BIGINT              NOT NULL IDENTITY,
    [StrFirstName]                      VARCHAR(64)             NULL DEFAULT NULL,
    [StrLastName]                       VARCHAR(64)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Client')
CREATE TABLE [dbo].[Client] (
    [IntId]                             BIGINT              NOT NULL IDENTITY,
    [StrClientName]                     VARCHAR(128)            NULL DEFAULT NULL,
    [StrContactMobile]                  VARCHAR(128)            NULL DEFAULT NULL,
    [StrContactMail]                    VARCHAR(128)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Service')
CREATE TABLE [dbo].[Service] (
    [IntId]                             BIGINT              NOT NULL IDENTITY,
    [StrServiceName]                    VARCHAR(128)            NULL DEFAULT NULL,
    [IntDuration]                       BIGINT                  NULL DEFAULT NULL,
    [DecPrice]                          DECIMAL(10, 2)          NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ServiceProvided')
CREATE TABLE [dbo].[ServiceProvided] (
    [IntId]                             BIGINT              NOT NULL IDENTITY,
    [IntAppointmentI]                   BIGINT                  NULL DEFAULT NULL,
    [IntServiceId]                      BIGINT                  NULL DEFAULT NULL,
    [DecPrice]                          DECIMAL(10, 2)          NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ServiceBooked')
CREATE TABLE [dbo].[ServiceBooked] (
    [IntId]                             BIGINT              NOT NULL IDENTITY,
    [IntAppointmentI]                   BIGINT                  NULL DEFAULT NULL,
    [IntServiceId]                      BIGINT                  NULL DEFAULT NULL,
    [DecPrice]                          DECIMAL(10, 2)          NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Appointment')
CREATE TABLE [dbo].[Appointment] (
    [IntId]                             BIGINT              NOT NULL IDENTITY,
    [DtDateCreated]                     DATETIME                NULL DEFAULT NULL,
    [IntEmployeeCreated]                BIGINT                  NULL DEFAULT NULL,
    [IntClientId]                       BIGINT                  NULL DEFAULT NULL,
    [IntEmployeeId]                     BIGINT                  NULL DEFAULT NULL,
    [StrClientName]                     VARCHAR(128)            NULL DEFAULT NULL,
    [StrClientContact]                  VARCHAR(128)            NULL DEFAULT NULL,
    [DtStartTime]                       DATETIME                NULL DEFAULT NULL,
    [DtEndTimeExpected]                 DATETIME                NULL DEFAULT NULL,
    [DtEndTime]                         DATETIME                NULL DEFAULT NULL,
    [DecPriceExpected]                  DECIMAL(10, 2)          NULL DEFAULT NULL,
    [DecPriceFull]                      DECIMAL(10, 2)          NULL DEFAULT NULL,
    [DecDiscount]                       DECIMAL(10, 2)          NULL DEFAULT NULL,
    [DecPriceFinal]                     DECIMAL(10, 2)          NULL DEFAULT NULL,
    [BitCanceled]                       BIT                     NULL DEFAULT NULL,
    [TxtCancelationReason]              TEXT                    NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntId])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Schedule]
    ADD CONSTRAINT [FkScheduleEmployeeId]
        FOREIGN KEY ([IntEmployeeId])
        REFERENCES [Employee] ([IntId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [ServiceBooked]
    ADD CONSTRAINT [FkServiceBookedServiceId]
        FOREIGN KEY ([IntServiceId])
        REFERENCES [Service] ([IntId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkServiceBookedAppointmentI]
        FOREIGN KEY ([IntAppointmentI])
        REFERENCES [Appointment] ([IntId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [ServiceProvided]
    ADD CONSTRAINT [FkServiceProvidedServiceId]
        FOREIGN KEY ([IntServiceId])
        REFERENCES [Service] ([IntId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkServiceProvidedAppointmentI]
        FOREIGN KEY ([IntAppointmentI])
        REFERENCES [Appointment] ([IntId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Appointment]
    ADD CONSTRAINT [FkAppointmentEmployeeCreated]
        FOREIGN KEY ([IntEmployeeCreated])
        REFERENCES [Employee] ([IntId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkAppointmentEmployeeId]
        FOREIGN KEY ([IntEmployeeId])
        REFERENCES [Employee] ([IntId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkAppointmentClientId]
        FOREIGN KEY ([IntClientId])
        REFERENCES [Client] ([IntId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;
