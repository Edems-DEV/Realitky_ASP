CREATE DATABASE IF NOT EXISTS `myDb`;
USE `myDb`;

-- Create the Roles table first
CREATE TABLE `Roles` (
  `Id` INT PRIMARY KEY,
  `name` VARCHAR(255)
);

-- Now create the Users table
CREATE TABLE `Users` (
  `Id` INT PRIMARY KEY AUTO_INCREMENT,
  `IdRole` INT,
  `username` VARCHAR(255),
  `password` VARCHAR(255),
  `name` VARCHAR(255),
  `email` VARCHAR(255),
  `phone` VARCHAR(255),
  `avatar` VARCHAR(255),
  CONSTRAINT `fk_Users_IdRole` FOREIGN KEY (`IdRole`) REFERENCES `Roles` (`Id`)
);

-- Create the Type table
CREATE TABLE `Type` (
  `Id` INT PRIMARY KEY,
  `name` VARCHAR(255)
);

-- Create the Region table
CREATE TABLE `Region` (
  `Id` INT PRIMARY KEY,
  `name` VARCHAR(255)
);

-- Create the Offers table with references to Type, Region, and Users tables
CREATE TABLE `Offers` (
  `Id` INT PRIMARY KEY AUTO_INCREMENT,
  `title` VARCHAR(255),
  `price` INT,
  `thumbnail` VARCHAR(255),
  `summary` VARCHAR(500),
  `IdType` INT,
  `IdRegion` INT,
  `IsRent` BIT,
  `size` INT,
  `body` TEXT,
  `address` VARCHAR(255),
  `IdDealer` INT,
  `IsVisible` BIT,
  CONSTRAINT `fk_Offers_IdType` FOREIGN KEY (`IdType`) REFERENCES `Type` (`Id`),
  CONSTRAINT `fk_Offers_IdRegion` FOREIGN KEY (`IdRegion`) REFERENCES `Region` (`Id`),
  CONSTRAINT `fk_Offers_IdDealer` FOREIGN KEY (`IdDealer`) REFERENCES `Users` (`Id`)
);

-- Create the Parametrs table
CREATE TABLE `Parametrs` (
  `Id` INT PRIMARY KEY AUTO_INCREMENT,
  `name` VARCHAR(255)
);

-- Create the ParametrsOffers table with references to Offers and Parametrs tables
CREATE TABLE `ParametersOffers` (
  `IdOffer` INT,
  `IdParametr` INT,
  `value` VARCHAR(255),
  CONSTRAINT `fk_ParametrsOffers_IdOffer` FOREIGN KEY (`IdOffer`) REFERENCES `Offers` (`Id`),
  CONSTRAINT `fk_ParametrsOffers_IdParametr` FOREIGN KEY (`IdParametr`) REFERENCES `Parametrs` (`Id`)
);

-- Create the Gallery table with references to Offers table
CREATE TABLE `Gallery` (
  `Id` INT PRIMARY KEY AUTO_INCREMENT,
  `IdOffer` INT,
  `path` VARCHAR(255),
  CONSTRAINT `fk_Gallery_IdOffer` FOREIGN KEY (`IdOffer`) REFERENCES `Offers` (`Id`)
);

-- Create the Request table with references to Offers table
CREATE TABLE `Request` (
  `Id` INT PRIMARY KEY AUTO_INCREMENT,
  `IdOffer` INT,
  `text` VARCHAR(255),
  `name` VARCHAR(255),
  `email` VARCHAR(255),
  `phone` VARCHAR(255),
  CONSTRAINT `fk_Request_IdOffer` FOREIGN KEY (`IdOffer`) REFERENCES `Offers` (`Id`)
);



---------------------------------------------
----   Data for table
---------------------------------------------

USE `myDb`;

-- Regions
INSERT INTO `Region` (`Id`, `name`) VALUES
('1', 'Praha'),
('2', 'Středočeský kraj'),
('3', 'Jihočeský kraj'),
('4', 'Plzeňský kraj'),
('5', 'Karlovarský kraj'),
('6', 'Ústecký kraj'),
('7', 'Liberecký kraj'),
('8', 'Královéhradecký kraj'),
('9', 'Pardubický kraj'),
('10', 'Kraj Vysočina'),
('11', 'Jihomoravský kraj'),
('12', 'Olomoucký kraj'),
('13', 'Moravskoslezský kraj'),
('14', 'Zlínský kraj');

-- Roles
INSERT INTO `Roles` (`Id`, `name`) VALUES
('0', 'User'),
('1', 'Dealer'),
('2', 'Admin');

-- Types
INSERT INTO `Type` (`Id`, `name`) VALUES
('0', 'Byt'),
('1', 'Dům'),
('2', 'Chata'),
('3', 'Pozemek');

-- Parametrs
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
(NULL, '2', 'admin', '123456', 'admin', 'admin@gmail.com', '+420 666 777 888', 'user-nicholas-lane-80x80.jpg'),
(NULL, '1', 'dealer', '123456', 'Ing. Jarmila Vostrá', 'jarmila@vostra.cz', '+420 666 777 888', 'user-lisa-evans-80x80.jpg'),
(NULL, '1', 'dealer2', '123456', 'Jaroslav Kopřiva', 'jk@intense.cz', '+420 666 777 888', 'user-ethan-dean-80x80.jpg'),
(NULL, '0', 'User1', '123456', 'Pavel Nový', 'pn@gmail.com', '+420 666 777 888', 'user-nicholas-lane-80x80.jpg');

-- Offers
INSERT INTO `Offers` (`Id`, `title`, `price`, `thumbnail`, `summary`, `IdType`, `IdRegion`, `IsRent`, `size`, `body`, `address`, `IdDealer`, `IsVisible`) VALUES
(NULL, 'AVA Nob Hill', '11500', 'home-img-07-370x250.jpg', 'AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community.', '0', '1', b'1', '50', 'Exkluzivně nabízíme prostorný, výborně řešený byt 3+1/L o celkové výměře 81 m2 (včetně lodžie plus sklep), který se nachází ve 4.NP zatepleného zrekonstruovaného domu, v příjemné a klidné lokalitě Praha 9 – Horní Počernice. Byt má zděnou koupelnu s vanou a samostatné WC, vstupní předsíň, dvě ložnice o výměře 12,6 m2 a 12,5 m2, obývací pokoj 22 m2 a kuchyň s jídelnou o výměře 12,4 m2. Na jižně orientovanou lodžii je vstup z obývacího pokoje a je z ní hezký výhled do otevřeného prostoru a na dětské hřiště. Ložnice jsou orientované na severní stranu. Na podlaze je dlažba, laminátová plovoucí podlaha a koberec, okna jsou plastová se žaluziemi. Byt je vybaven kuchyňskou linkou na míru s vestavěnou elektrickou troubou a sklokeramickou varnou deskou, vestavěnými skříněmi v předsíni a v ložnici. Další vybavení bytu může po dohodě také zůstat. K bytu náleží sklepní kóje cca 4 m2 a lze využívat kočárkárnu/kolárnu umístěnou v přízemí domu. Měsíční poplatky jsou pro čtyřčlennou rodinu cca 5 300,- včetně fondu oprav, který je ve výši 1 000,-Kč. Výborně fungující SVJ je pouze jeden vchod domu o jedenácti bytových jednotkách. SVJ není zatíženo žádným úvěrem. Poloha zrekonstruovaného zatepleného panelového domu je velice výhodná. Přímo u domu je Penny Market a lékárna, v pěším dosahu je pak veškerá občanská vybavenost – MŠ, ZŠ, SOŠ, lékaři, obchody, restaurace, divadlo, několik dětských hřišť a sportovišť. K větším procházkám a sportovnímu vyžití Vás naláká Klánovický les. Stanice metra B – Černý Most je vzdálena jednu cca 1,2 KM od domu a na metro se tak můžete dostat i pěšky nebo pohodlně dojet autobusem za 3 minuty. Nemovitost doporučuji pro pohodlné, klidné rodinné bydlení. Osobní vlastnictví s možností financování hypotékou, kterou Vám rádi pomůžeme vyřídit.', 'Mezilesí, Praha 9 - Prosek', '2', b'1'),
(NULL, 'SF Flat', '5000000', 'home-img-05-370x250.jpg', 'AVA Nob Hill includes studios and 1 and 2 bedroom apartments that feature an urban-inspired design that extends beyond your walls and throughout the entire community.', '1', '2', b'0', '100', 'Exkluzivně nabízíme prostorný, výborně řešený byt 3+1/L o celkové výměře 81 m2 (včetně lodžie plus sklep), který se nachází ve 4.NP zatepleného zrekonstruovaného domu, v příjemné a klidné lokalitě Praha 9 – Horní Počernice. Byt má zděnou koupelnu s vanou a samostatné WC, vstupní předsíň, dvě ložnice o výměře 12,6 m2 a 12,5 m2, obývací pokoj 22 m2 a kuchyň s jídelnou o výměře 12,4 m2. Na jižně orientovanou lodžii je vstup z obývacího pokoje a je z ní hezký výhled do otevřeného prostoru a na dětské hřiště. Ložnice jsou orientované na severní stranu. Na podlaze je dlažba, laminátová plovoucí podlaha a koberec, okna jsou plastová se žaluziemi. Byt je vybaven kuchyňskou linkou na míru s vestavěnou elektrickou troubou a sklokeramickou varnou deskou, vestavěnými skříněmi v předsíni a v ložnici. Další vybavení bytu může po dohodě také zůstat. K bytu náleží sklepní kóje cca 4 m2 a lze využívat kočárkárnu/kolárnu umístěnou v přízemí domu. Měsíční poplatky jsou pro čtyřčlennou rodinu cca 5 300,- včetně fondu oprav, který je ve výši 1 000,-Kč. Výborně fungující SVJ je pouze jeden vchod domu o jedenácti bytových jednotkách. SVJ není zatíženo žádným úvěrem. Poloha zrekonstruovaného zatepleného panelového domu je velice výhodná. Přímo u domu je Penny Market a lékárna, v pěším dosahu je pak veškerá občanská vybavenost – MŠ, ZŠ, SOŠ, lékaři, obchody, restaurace, divadlo, několik dětských hřišť a sportovišť. K větším procházkám a sportovnímu vyžití Vás naláká Klánovický les. Stanice metra B – Černý Most je vzdálena jednu cca 1,2 KM od domu a na metro se tak můžete dostat i pěšky nebo pohodlně dojet autobusem za 3 minuty. Nemovitost doporučuji pro pohodlné, klidné rodinné bydlení. Osobní vlastnictví s možností financování hypotékou, kterou Vám rádi pomůžeme vyřídit.', 'Mezilesí, Praha 9 - Prosek', '2', b'1');

-- ParametersOffers
INSERT INTO `ParametersOffers` (`IdOffer`, `IdParametr`, `value`) VALUES
('1', '1', 'Cihlová'),
('1', '2', 'Po rekonstrukci'),
('1', '3', 'Osobní'),
('1', '4', 'Výborný'),
('1', '5', '81 m2'),
('1', '6', '4'),
('1', '7', '4'),
('1', '8', 'Kuchyňská linka, vestavěné skříně'),
('1', '9', 'Ano'),
('1', '10', 'Ano');

-- AttributesOffers
-- INSERT INTO `AttributesOffers` (`Id`, `IdOffer`, `name`) VALUES
-- (NULL, '1', 'Výtah'),
-- (NULL, '1', 'Sklep');

