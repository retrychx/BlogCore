drop database if exists BlogDB;
create database BlogDB;

use BlogDB;

SET FOREIGN_KEY_CHECKS=0;

DROP TABLE IF EXISTS `Advertisement`;
CREATE TABLE `Advertisement` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CreateDate` datetime NOT NULL,
  `ImgUrl` varchar(255) NULL,
  `Title` varchar(255)  NULL,
  `Url` varchar(255)  NULL,
  `Remark` varchar(20000) NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=gbk;

DROP TABLE IF EXISTS `BlogArticle`;
CREATE TABLE `BlogArticle` (
    `bID` int(11) NOT NULL AUTO_INCREMENT,
    `bsubmitter` varchar(60) NULL,
    `btitle` varchar(256) NULL,
    `bcategory` text NULL,
    `bcontent` text NULL,
    `btraffic` int NOT NULL,
    `bcommentNum` text NULL,
    `bUpdateTime` datetime NOT NULL,
    `bCreateTime` datetime NOT NULL,
    `bRemark` text NULL,
    PRIMARY KEY(`bID`)
) ENGINE=MyISAM DEFAULT CHARSET=gbk;

DROP TABLE IF EXISTS `Guestbook`;
CREATE TABLE `Guestbook` (
    `id` int(11) NOT NULL AUTO_INCREMENT,
    `blogId` int NOT NULL,
    `createdate` datetime NOT NULL,
    `username` text NULL,
    `phone` text NULL,
    `QQ` int NOT NULL,
    `body` text NULL,
    `ip` text NULL,
    `isshow` bit(1) NOT NULL,
    PRIMARY KEY(`id`)
) ENGINE=MyISAM DEFAULT CHARSET=gbk;

DROP TABLE IF EXISTS `Module`;
CREATE TABLE `Module` (
    `Id` int(11) NOT NULL AUTO_INCREMENT,
    `IsDeleted` bit(1) NOT NULL,
    `ParentId` in NULL,
    `Name` varchar(255) NULL,
    `LinkUrl` varchar(256) NULL,
    `Area` text NULL,
    `Icon` varchar(100) NULL,
    PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=gbk;