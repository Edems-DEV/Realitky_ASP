CREATE DATABASE IF NOT EXISTS `myDb`;
USE `myDb`;

/*!999999\- enable the sandbox mode */
-- MariaDB dump 10.19  Distrib 10.6.18-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: myDb
-- ------------------------------------------------------
-- Server version	10.6.18-MariaDB-ubu2004

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Favorite`
--

DROP TABLE IF EXISTS `Favorite`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Favorite` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdUser` int(11) NOT NULL,
  `IdOffer` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Favorite_IdOffer` (`IdOffer`),
  KEY `IX_Favorite_IdUser` (`IdUser`),
  CONSTRAINT `FK_Favorite_Offers_IdOffer` FOREIGN KEY (`IdOffer`) REFERENCES `Offers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Favorite_Users_IdUser` FOREIGN KEY (`IdUser`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Favorite`
--

LOCK TABLES `Favorite` WRITE;
/*!40000 ALTER TABLE `Favorite` DISABLE KEYS */;
/*!40000 ALTER TABLE `Favorite` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Gallery`
--

DROP TABLE IF EXISTS `Gallery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Gallery` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdOffer` int(11) NOT NULL,
  `path` longtext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Gallery_IdOffer` (`IdOffer`),
  CONSTRAINT `FK_Gallery_Offers_IdOffer` FOREIGN KEY (`IdOffer`) REFERENCES `Offers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Gallery`
--

LOCK TABLES `Gallery` WRITE;
/*!40000 ALTER TABLE `Gallery` DISABLE KEYS */;
/*!40000 ALTER TABLE `Gallery` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Message`
--

DROP TABLE IF EXISTS `Message`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Message` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdThread` int(11) NOT NULL,
  `IdSender` int(11) NOT NULL,
  `content` longtext NOT NULL,
  `sent_at` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Message_IdSender` (`IdSender`),
  KEY `IX_Message_IdThread` (`IdThread`),
  CONSTRAINT `FK_Message_Offers_IdThread` FOREIGN KEY (`IdThread`) REFERENCES `Offers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Message_Users_IdSender` FOREIGN KEY (`IdSender`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Message`
--

LOCK TABLES `Message` WRITE;
/*!40000 ALTER TABLE `Message` DISABLE KEYS */;
/*!40000 ALTER TABLE `Message` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Offers`
--

DROP TABLE IF EXISTS `Offers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Offers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `title` longtext DEFAULT NULL,
  `price` int(11) DEFAULT NULL,
  `thumbnail` longtext DEFAULT NULL,
  `summary` longtext DEFAULT NULL,
  `IdType` int(11) DEFAULT NULL,
  `IdRegion` int(11) DEFAULT NULL,
  `IsRent` tinyint(1) NOT NULL,
  `size` int(11) DEFAULT NULL,
  `body` longtext DEFAULT NULL,
  `address` longtext DEFAULT NULL,
  `IdDealer` int(11) DEFAULT NULL,
  `IsVisible` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Offers_IdDealer` (`IdDealer`),
  KEY `IX_Offers_IdRegion` (`IdRegion`),
  KEY `IX_Offers_IdType` (`IdType`),
  CONSTRAINT `FK_Offers_Region_IdRegion` FOREIGN KEY (`IdRegion`) REFERENCES `Region` (`Id`),
  CONSTRAINT `FK_Offers_Type_IdType` FOREIGN KEY (`IdType`) REFERENCES `Type` (`Id`),
  CONSTRAINT `FK_Offers_Users_IdDealer` FOREIGN KEY (`IdDealer`) REFERENCES `Users` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Offers`
--

LOCK TABLES `Offers` WRITE;
/*!40000 ALTER TABLE `Offers` DISABLE KEYS */;
/*!40000 ALTER TABLE `Offers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Parametrs`
--

DROP TABLE IF EXISTS `Parametrs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Parametrs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Parametrs`
--

LOCK TABLES `Parametrs` WRITE;
/*!40000 ALTER TABLE `Parametrs` DISABLE KEYS */;
/*!40000 ALTER TABLE `Parametrs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ParametrsOffers`
--

DROP TABLE IF EXISTS `ParametrsOffers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ParametrsOffers` (
  `IdOffer` int(11) NOT NULL,
  `IdParametr` int(11) NOT NULL,
  `value` longtext NOT NULL,
  PRIMARY KEY (`IdOffer`,`IdParametr`),
  KEY `IX_ParametrsOffers_IdParametr` (`IdParametr`),
  CONSTRAINT `FK_ParametrsOffers_Offers_IdOffer` FOREIGN KEY (`IdOffer`) REFERENCES `Offers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ParametrsOffers_Parametrs_IdParametr` FOREIGN KEY (`IdParametr`) REFERENCES `Parametrs` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ParametrsOffers`
--

LOCK TABLES `ParametrsOffers` WRITE;
/*!40000 ALTER TABLE `ParametrsOffers` DISABLE KEYS */;
/*!40000 ALTER TABLE `ParametrsOffers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Region`
--

DROP TABLE IF EXISTS `Region`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Region` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Region`
--

LOCK TABLES `Region` WRITE;
/*!40000 ALTER TABLE `Region` DISABLE KEYS */;
/*!40000 ALTER TABLE `Region` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Request`
--

DROP TABLE IF EXISTS `Request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Request` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdOffer` int(11) NOT NULL,
  `text` longtext NOT NULL,
  `name` longtext NOT NULL,
  `email` longtext NOT NULL,
  `phone` longtext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Request_IdOffer` (`IdOffer`),
  CONSTRAINT `FK_Request_Offers_IdOffer` FOREIGN KEY (`IdOffer`) REFERENCES `Offers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Request`
--

LOCK TABLES `Request` WRITE;
/*!40000 ALTER TABLE `Request` DISABLE KEYS */;
/*!40000 ALTER TABLE `Request` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Request_user`
--

DROP TABLE IF EXISTS `Request_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Request_user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdOffer` int(11) NOT NULL,
  `IdUser` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Request_user_IdOffer` (`IdOffer`),
  KEY `IX_Request_user_IdUser` (`IdUser`),
  CONSTRAINT `FK_Request_user_Offers_IdOffer` FOREIGN KEY (`IdOffer`) REFERENCES `Offers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Request_user_Users_IdUser` FOREIGN KEY (`IdUser`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Request_user`
--

LOCK TABLES `Request_user` WRITE;
/*!40000 ALTER TABLE `Request_user` DISABLE KEYS */;
/*!40000 ALTER TABLE `Request_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Roles`
--

DROP TABLE IF EXISTS `Roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Roles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Roles`
--

LOCK TABLES `Roles` WRITE;
/*!40000 ALTER TABLE `Roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `Roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Type`
--

DROP TABLE IF EXISTS `Type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Type` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Type`
--

LOCK TABLES `Type` WRITE;
/*!40000 ALTER TABLE `Type` DISABLE KEYS */;
/*!40000 ALTER TABLE `Type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdRole` int(11) DEFAULT NULL,
  `username` longtext DEFAULT NULL,
  `password` longtext DEFAULT NULL,
  `name` longtext DEFAULT NULL,
  `email` longtext DEFAULT NULL,
  `phone` longtext DEFAULT NULL,
  `avatar` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Users_IdRole` (`IdRole`),
  CONSTRAINT `FK_Users_Roles_IdRole` FOREIGN KEY (`IdRole`) REFERENCES `Roles` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;


--------------------------------------------------
----------------- INSERT DATA ---------------------
--------------------------------------------------

-- Regions
INSERT INTO `Region` (`Id`, `name`) VALUES
(1, 'Praha'),
(2, 'Středočeský kraj'),
(3, 'Jihočeský kraj'),
(4, 'Plzeňský kraj'),
(5, 'Karlovarský kraj'),
(6, 'Ústecký kraj'),
(7, 'Liberecký kraj'),
(8, 'Královéhradecký kraj'),
(9, 'Pardubický kraj'),
(10, 'Kraj Vysočina'),
(11, 'Jihomoravský kraj'),
(12, 'Olomoucký kraj'),
(13, 'Moravskoslezský kraj'),
(14, 'Zlínský kraj');

-- Roles
INSERT INTO `Roles` (`Id`, `name`) VALUES
(0, 'User'),
(1, 'Dealer'),
(2, 'Admin');

-- Types
INSERT INTO `Type` (`Id`, `name`) VALUES
(0, 'Byt'),
(1, 'Dům'),
(2, 'Chata'),
(3, 'Pozemek');

-- Parameters
INSERT INTO `Parametrs` (`Id`, `name`) VALUES
(NULL, 'Konstrukce budovy'),
(NULL, 'Stav budovy'),
(NULL, 'Vlastnictví'),
(NULL, 'Stav bytu'),
(NULL, 'Užitná plocha bytu'),
(NULL, 'Počet podlaží budovy'),
(NULL, 'Podlaží bytu'),
(NULL, 'Vybavení'),
(NULL, 'Lodžie'),
(NULL, 'Připojení k internetu');

-- Users
INSERT INTO `Users` (`Id`, `IdRole`, `username`, `password`, `name`, `email`, `phone`, `avatar`) VALUES
(NULL, 2, 'admin', '123456', 'admin', 'admin@gmail.com', '+420 666 777 888', 'user-nicholas-lane-80x80.jpg'),
(NULL, 1, 'dealer', '123456', 'Ing. Jarmila Vostrá', 'jarmila@vostra.cz', '+420 666 777 888', 'user-lisa-evans-80x80.jpg'),
(NULL, 1, 'dealer2', '123456', 'Jaroslav Kopřiva', 'jk@intense.cz', '+420 666 777 888', 'user-ethan-dean-80x80.jpg'),
(NULL, 1, 'User1', '123456', 'Pavel Nový', 'pn@gmail.com', '+420 666 777 888', 'user-nicholas-lane-80x80.jpg');

-- Offers
INSERT INTO `Offers` (`Id`, `title`, `price`, `thumbnail`, `summary`, `IdType`, `IdRegion`, `IsRent`, `size`, `body`, `address`, `IdDealer`, `IsVisible`) VALUES
(NULL, 'AVA Nob Hill', 11500, 'home-img-07-370x250.jpg', 'AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community.', 0, 1, b'1', 50, 'Exkluzivně nabízíme prostorný, výborně řešený byt 3+1/L o celkové výměře 81 m2 (včetně lodžie plus sklep), který se nachází ve 4.NP zatepleného zrekonstruovaného domu, v příjemné a klidné lokalitě Praha 9 – Horní Počernice. Byt má zděnou koupelnu s vanou a samostatné WC, vstupní předsíň, dvě ložnice o výměře 12,6 m2 a 12,5 m2, obývací pokoj 22 m2 a kuchyň s jídelnou o výměře 12,4 m2. Na jižně orientovanou lodžii je vstup z obývacího pokoje a je z ní hezký výhled do otevřeného prostoru a na dětské hřiště. Ložnice jsou orientované na severní stranu. Na podlaze je dlažba, laminátová plovoucí podlaha a koberec, okna jsou plastová se žaluziemi. Byt je vybaven kuchyňskou linkou na míru s vestavěnou elektrickou troubou a sklokeramickou varnou deskou, vestavěnými skříněmi v předsíni a v ložnici. Další vybavení bytu může po dohodě také zůstat. K bytu náleží sklepní kóje cca 4 m2 a lze využívat kočárkárnu/kolárnu umístěnou v přízemí domu. Měsíční poplatky jsou pro čtyřčlennou rodinu cca 5 300,- včetně fondu oprav, který je ve výši 1 000,-Kč. Výborně fungující SVJ je pouze jeden vchod domu o jedenácti bytových jednotkách. SVJ není zatíženo žádným úvěrem. Poloha zrekonstruovaného zatepleného panelového domu je velice výhodná. Přímo u domu je Penny Market a lékárna, v pěším dosahu je pak veškerá občanská vybavenost – MŠ, ZŠ, SOŠ, lékaři, obchody, restaurace, divadlo, několik dětských hřišť a sportovišť. K větším procházkám a sportovnímu vyžití Vás naláká Klánovický les. Stanice metra B – Černý Most je vzdálena jednu cca 1,2 KM od domu a na metro se tak můžete dostat i pěšky nebo pohodlně dojet autobusem za 3 minuty. Nemovitost doporučuji pro pohodlné, klidné rodinné bydlení. Osobní vlastnictví s možností financování hypotékou, kterou Vám rádi pomůžeme vyřídit.', 'Mezilesí, Praha 9 - Prosek', 2, b'1'),
(NULL, 'SF Flat', 5000000, 'home-img-05-370x250.jpg', 'AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community.', 1, 2, b'0', 100, 'Exkluzivně nabízíme prostorný, výborně řešený byt 3+1/L o celkové výměře 81 m2 (včetně lodžie plus sklep), který se nachází ve 4.NP zatepleného zrekonstruovaného domu, v příjemné a klidné lokalitě Praha 9 – Horní Počernice. Byt má zděnou koupelnu s vanou a samostatné WC, vstupní předsíň, dvě ložnice o výměře 12,6 m2 a 12,5 m2, obývací pokoj 22 m2 a kuchyň s jídelnou o výměře 12,4 m2. Na jižně orientovanou lodžii je vstup z obývacího pokoje a je z ní hezký výhled do otevřeného prostoru a na dětské hřiště. Ložnice jsou orientované na severní stranu. Na podlaze je dlažba, laminátová plovoucí podlaha a koberec, okna jsou plastová se žaluziemi. Byt je vybaven kuchyňskou linkou na míru s vestavěnou elektrickou troubou a sklokeramickou varnou deskou, vestavěnými skříněmi v předsíni a v ložnici. Další vybavení bytu může po dohodě také zůstat. K bytu náleží sklepní kóje cca 4 m2 a lze využívat kočárkárnu/kolárnu umístěnou v přízemí domu. Měsíční poplatky jsou pro čtyřčlennou rodinu cca 5 300,- včetně fondu oprav, který je ve výši 1 000,-Kč. Výborně fungující SVJ je pouze jeden vchod domu o jedenácti bytových jednotkách. SVJ není zatíženo žádným úvěrem. Poloha zrekonstruovaného zatepleného panelového domu je velice výhodná. Přímo u domu je Penny Market a lékárna, v pěším dosahu je pak veškerá občanská vybavenost – MŠ, ZŠ, SOŠ, lékaři, obchody, restaurace, divadlo, několik dětských hřišť a sportovišť. K větším procházkám a sportovnímu vyžití Vás naláká Klánovický les. Stanice metra B – Černý Most je vzdálena jednu cca 1,2 KM od domu a na metro se tak můžete dostat i pěšky nebo pohodlně dojet autobusem za 3 minuty. Nemovitost doporučuji pro pohodlné, klidné rodinné bydlení. Osobní vlastnictví s možností financování hypotékou, kterou Vám rádi pomůžeme vyřídit.x', 'Mezilesí, Praha 9 - Prosek', 2, b'1');

-- ParametersOffers
INSERT INTO `ParametrsOffers` (`IdOffer`, `IdParametr`, `value`) VALUES
(1, 1, 'Cihlová'),
(1, 2, 'Po rekonstrukci'),
(1, 3, 'Osobní'),
(1, 4, 'Výborný'),
(1, 5, '81 m2'),
(1, 6, '4'),
(1, 7, '4'),
(1, 8, 'Kuchyňská linka, vestavěné skříně'),
(1, 9, 'Ano'),
(1, 10, 'Ano');