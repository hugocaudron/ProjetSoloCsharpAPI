CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Admin` (
    `ID` int(11) NOT NULL AUTO_INCREMENT,
    `Email` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
    `Password_Hash` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
    `Password_Salt` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`ID`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `Salariés` (  
    `Id` int(11) NOT NULL AUTO_INCREMENT,
    `Nom` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
    `Prénom` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
    `Tel_Fixe` int(11) NOT NULL,
    `Tel_Portable` int(11) NOT NULL,
    `Email` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
    `ID_Services` int(11) NOT NULL,
    `ID_Site` int(11) NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `Services` (
    `ID` int(11) NOT NULL AUTO_INCREMENT,
    `Service` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`ID`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `Sites` (
    `ID` int(11) NOT NULL AUTO_INCREMENT,
    `Ville` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`ID`)
) CHARACTER SET=utf8mb4 COLLATE=utf8mb4_general_ci;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20250316093054_InitialCreate', '8.0.2');

COMMIT;

