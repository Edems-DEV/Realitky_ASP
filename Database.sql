CREATE TABLE `Users` (
  `Id` integer PRIMARY KEY AUTO_INCREMENT,
  `IdRole` integer,
  `username` varchar(255),
  `password` varchar(255),
  `name` varchar(255),
  `email` varchar(255),
  `phone` varchar(255),
  `avatar` varchar(255)
);

CREATE TABLE `Roles` (
  `Id` integer PRIMARY KEY,
  `name` varchar(255)
);

CREATE TABLE `Offers` (
  `Id` integer PRIMARY KEY AUTO_INCREMENT,
  `title` varchar(255),
  `price` integer,
  `thumbnail` varchar(255),
  `summary` varchar(500),
  `IdType` integer,
  `IdRegion` integer,
  `IsRent` bit,
  `size` integer,
  `body` text,
  `address` varchar(255),
  `IdDealer` int,
  `IsVisible` bit
);

CREATE TABLE `Type` (
  `Id` integer PRIMARY KEY,
  `name` varchar(255)
);

CREATE TABLE `Region` (
  `Id` integer PRIMARY KEY,
  `name` varchar(255)
);

CREATE TABLE `ParametrsOffers` (
  `IdOffer` integer,
  `IdParametr` integer,
  `value` varchar(255)
);

CREATE TABLE `Parametrs` (
  `Id` integer PRIMARY KEY AUTO_INCREMENT,
  `name` varchar(255)
);

CREATE TABLE `Gallery` (
  `Id` integer PRIMARY KEY AUTO_INCREMENT,
  `IdOffer` integer,
  `path` varchar(255)
);

CREATE TABLE `Request` (
  `Id` integer PRIMARY KEY AUTO_INCREMENT,
  `IdOffer` integer,
  `text` varchar(255),
  `name` varchar(255),
  `email` varchar(255),
  `phone` varchar(255)
);

ALTER TABLE `Users` ADD FOREIGN KEY (`IdRole`) REFERENCES `Roles` (`Id`);

ALTER TABLE `Offers` ADD FOREIGN KEY (`IdType`) REFERENCES `Type` (`Id`);

ALTER TABLE `Offers` ADD FOREIGN KEY (`IdRegion`) REFERENCES `Region` (`Id`);

ALTER TABLE `Offers` ADD FOREIGN KEY (`IdDealer`) REFERENCES `Users` (`Id`);

ALTER TABLE `ParametrsOffers` ADD FOREIGN KEY (`IdOffer`) REFERENCES `Offers` (`Id`);

ALTER TABLE `ParametrsOffers` ADD FOREIGN KEY (`IdParametr`) REFERENCES `Parametrs` (`Id`);

ALTER TABLE `Gallery` ADD FOREIGN KEY (`IdOffer`) REFERENCES `Offers` (`Id`);

ALTER TABLE `Request` ADD FOREIGN KEY (`IdOffer`) REFERENCES `Offers` (`Id`);
