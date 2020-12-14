-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 03-12-2020 a las 20:53:30
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `datos_proyecto`
--
CREATE DATABASE IF NOT EXISTS `datos_proyecto` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `datos_proyecto`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(127) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(127) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(127) NOT NULL,
  `ProviderKey` varchar(127) NOT NULL,
  `ProviderDisplayName` text DEFAULT NULL,
  `UserId` varchar(767) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(127) NOT NULL,
  `RoleId` varchar(127) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` text DEFAULT NULL,
  `SecurityStamp` text DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL,
  `PhoneNumber` text DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('18e40581-2fa8-4230-a15b-55d8a93e5b9e', 'wdvelasquez0@misena.edu.co', 'WDVELASQUEZ0@MISENA.EDU.CO', 'wdvelasquez0@misena.edu.co', 'WDVELASQUEZ0@MISENA.EDU.CO', 0, 'AQAAAAEAACcQAAAAEA/vCJ591lEf9mYoO8yLVx0fKcnREmRD7jPTYT5ORfD0KtlXhM1AP5Llp9VZQckWTQ==', '2DGB7Z7UU67YKARGLFMOQGYM32VP7TKZ', 'cd0c519a-0358-4aef-833a-45a6432fab54', NULL, 0, 0, NULL, 1, 0),
('5e49738e-6dd0-42ed-a1e9-987ffb991658', 'wdevelasquez0@misena.edu.co', 'WDEVELASQUEZ0@MISENA.EDU.CO', 'wdevelasquez0@misena.edu.co', 'WDEVELASQUEZ0@MISENA.EDU.CO', 0, 'AQAAAAEAACcQAAAAEJ2cj3S3gQDsZAhZeuyVoQMjJl9PXzXUN1HPmMJhA9gOzl7OuCTaLw6ML4ysGLg28A==', 'B4NIOYRXFJP4ELQEV5475EFYBU5EXBDK', 'b4ae92e3-905d-400f-995e-e995b77d7065', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE IF NOT EXISTS `aspnetusertokens` (
  `UserId` varchar(127) NOT NULL,
  `LoginProvider` varchar(127) NOT NULL,
  `Name` varchar(127) NOT NULL,
  `Value` text DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estado`
--

DROP TABLE IF EXISTS `estado`;
CREATE TABLE IF NOT EXISTS `estado` (
  `Id_Estado` int(11) NOT NULL,
  `Nombre_Estado` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Id_Estado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `horario`
--

DROP TABLE IF EXISTS `horario`;
CREATE TABLE IF NOT EXISTS `horario` (
  `Id_Horario` int(11) NOT NULL,
  `Nombre_Horario` varchar(15) DEFAULT NULL,
  `Franja_Horaria` date DEFAULT NULL,
  PRIMARY KEY (`Id_Horario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `horario`
--

INSERT INTO `horario` (`Id_Horario`, `Nombre_Horario`, `Franja_Horaria`) VALUES
(101, 'mañana', '2020-11-30');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

DROP TABLE IF EXISTS `producto`;
CREATE TABLE IF NOT EXISTS `producto` (
  `Id_Producto` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre_Producto` varchar(25) DEFAULT NULL,
  `Cantidad_Disponible` int(11) DEFAULT NULL,
  `Medidas` varchar(5) DEFAULT NULL,
  `Id_Suministro` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_Producto`),
  KEY `Id_Suministro` (`Id_Suministro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `registro_ingreso`
--

DROP TABLE IF EXISTS `registro_ingreso`;
CREATE TABLE IF NOT EXISTS `registro_ingreso` (
  `Id_Registro` int(11) NOT NULL,
  `Nombre_Registro` varchar(15) DEFAULT NULL,
  `Fecha_Entrada` datetime DEFAULT NULL,
  `Fecha_Ingreso` datetime DEFAULT NULL,
  `Id_Horario` int(11) NOT NULL,
  `Id_Usuario` int(11) NOT NULL,
  PRIMARY KEY (`Id_Registro`),
  KEY `Id_Horario` (`Id_Horario`),
  KEY `Id_Usuario` (`Id_Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `solicitud`
--

DROP TABLE IF EXISTS `solicitud`;
CREATE TABLE IF NOT EXISTS `solicitud` (
  `Id_Solicitud` int(11) NOT NULL,
  `Nombre_Solicitud` varchar(25) DEFAULT NULL,
  `Fecha_Creada` datetime DEFAULT NULL,
  `Fecha_Respuesta` varchar(45) DEFAULT NULL,
  `Id_Estado` int(11) DEFAULT NULL,
  `Id_Usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_Solicitud`),
  KEY `Id_Estado` (`Id_Estado`),
  KEY `Id_Usuario` (`Id_Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `suministro`
--

DROP TABLE IF EXISTS `suministro`;
CREATE TABLE IF NOT EXISTS `suministro` (
  `Id_Suministro` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre_Suministro` varchar(25) DEFAULT NULL,
  `Id_Solicitud` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_Suministro`),
  KEY `Id_Solicitud` (`Id_Solicitud`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE IF NOT EXISTS `usuario` (
  `Id_Usuario` int(11) NOT NULL AUTO_INCREMENT,
  `N_Documento` int(11) DEFAULT NULL,
  `Primer_Nombre` varchar(10) DEFAULT NULL,
  `Segundo_Nombre` varchar(10) DEFAULT NULL,
  `Primer_Apellido` varchar(14) DEFAULT NULL,
  `Segundo_Apellido` varchar(14) DEFAULT NULL,
  `Direccion` varchar(25) DEFAULT NULL,
  `Id_Horario` int(11) DEFAULT NULL,
  `Id_Solicitud` int(11) DEFAULT NULL,
  `Id_Estado` int(11) DEFAULT NULL,
  `Aspnetusers_Id` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`Id_Usuario`),
  KEY `Id_Horario` (`Id_Horario`),
  KEY `Id_Solicitud` (`Id_Solicitud`),
  KEY `Id_Estado` (`Id_Estado`),
  KEY `Aspnetusers_Id` (`Aspnetusers_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`Id_Usuario`, `N_Documento`, `Primer_Nombre`, `Segundo_Nombre`, `Primer_Apellido`, `Segundo_Apellido`, `Direccion`, `Id_Horario`, `Id_Solicitud`, `Id_Estado`, `Aspnetusers_Id`) VALUES
(2, 1003487870, 'Mario', 'Mauricio', 'Torres', 'Martinez', 'calle 5 #56-67 sur', NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20201130221918_CreateIdentitySchema', '3.1.10');

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `producto`
--
ALTER TABLE `producto`
  ADD CONSTRAINT `producto_ibfk_1` FOREIGN KEY (`Id_Suministro`) REFERENCES `suministro` (`Id_Suministro`);

--
-- Filtros para la tabla `registro_ingreso`
--
ALTER TABLE `registro_ingreso`
  ADD CONSTRAINT `registro_ingreso_ibfk_1` FOREIGN KEY (`Id_Horario`) REFERENCES `horario` (`Id_Horario`),
  ADD CONSTRAINT `registro_ingreso_ibfk_2` FOREIGN KEY (`Id_Usuario`) REFERENCES `usuario` (`Id_Usuario`);

--
-- Filtros para la tabla `solicitud`
--
ALTER TABLE `solicitud`
  ADD CONSTRAINT `solicitud_ibfk_1` FOREIGN KEY (`Id_Estado`) REFERENCES `estado` (`Id_Estado`),
  ADD CONSTRAINT `solicitud_ibfk_2` FOREIGN KEY (`Id_Usuario`) REFERENCES `usuario` (`Id_Usuario`);

--
-- Filtros para la tabla `suministro`
--
ALTER TABLE `suministro`
  ADD CONSTRAINT `suministro_ibfk_1` FOREIGN KEY (`Id_Solicitud`) REFERENCES `solicitud` (`Id_Solicitud`);

--
-- Filtros para la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD CONSTRAINT `usuario_ibfk_2` FOREIGN KEY (`Id_Horario`) REFERENCES `horario` (`Id_Horario`),
  ADD CONSTRAINT `usuario_ibfk_3` FOREIGN KEY (`Id_Solicitud`) REFERENCES `solicitud` (`Id_Solicitud`),
  ADD CONSTRAINT `usuario_ibfk_4` FOREIGN KEY (`Id_Estado`) REFERENCES `estado` (`Id_Estado`),
  ADD CONSTRAINT `usuario_ibfk_5` FOREIGN KEY (`Aspnetusers_Id`) REFERENCES `aspnetusers` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
