CREATE TABLE IF NOT EXISTS `BookingDetails`(
	`Id` BIGINT NOT NULL AUTO_INCREMENT,
    
	`BookedFrom` datetime not null,
    `LeaveAt` datetime not null,
    `BookedBy` BIGINT not null,
    `Comments` varchar(300) null,
    
    `CreatedAt` DATETIME NOT NULL,
    `UpdatedAt` datetime NULL,
    
    PRIMARY KEY (`Id`)
);

CREATE TABLE IF NOT EXISTS `Rooms`(
	`Id` BIGINT NOT NULL AUTO_INCREMENT,
    
	`RoomNumber` varchar(200) not null,
    `Capacity` int not null,
    `Rent` decimal not null,
    
    `CreatedAt` DATETIME NOT NULL,
    `UpdatedAt` datetime NULL,
    
    primary key (`Id`)
);

CREATE TABLE IF NOT EXISTS `Bookings`(
	`Id` BIGINT NOT NULL AUTO_INCREMENT,
    
	`BookingId` BIGINT NOT NULL,
    `RoomId` BIGINT NOT NULL,
    
    `CreatedAt` DATETIME NOT NULL,
    `UpdatedAt` datetime NULL,
    
    primary key (`Id`),
	FOREIGN KEY(`BookingId`) REFERENCES `BookingDetails` (`Id`)  ON DELETE CASCADE ON UPDATE NO ACTION,
    FOREIGN KEY(`RoomId`) REFERENCES `Rooms` (`Id`)  ON DELETE CASCADE ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS `Guests`(
	`Id` BIGINT NOT NULL AUTO_INCREMENT,
    
    `Name` varchar(250) NOT NULL,
    `Age` int NOT NULL,
    `ContactNumber` varchar(250) NULL,
    
    `CreatedAt` DATETIME NOT NULL,
    `UpdatedAt` datetime NULL,
    
    primary key (`Id`)
);

CREATE TABLE IF NOT EXISTS `BookingSettings`(
	`Id` BIGINT NOT NULL AUTO_INCREMENT,
    
	`Discount` decimal NULL,
    `TaxPercentage` decimal NULL,
    
    `CreatedAt` DATETIME NOT NULL,
    `UpdatedAt` datetime NULL,
    
    primary key (`Id`)
);

CREATE UNIQUE INDEX KEY_INDEX ON `Rooms` (`RoomNumber`);