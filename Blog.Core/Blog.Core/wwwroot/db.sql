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
    `bsumitter` varchar(60) NULL,
    `btitle` varchar(256) NULL,
    `bcategory` text NULL,
    `bcontent` text NULL,
    `btraffice` int NOT NULL,
    `bUpdateTime` datetime NOT NULL,
    `bCreateTime` datetime NOT NULL,
    `bRemark` text NULL,
    PRIMARY KEY(`bID`)
) ENGINE=MyISAM DEFAULT CHARSET=gbk;

DROP TABLE IF EXISTS `Guestbook`; CREATE TABLE `Guestbook` ( `id` int(11) NOT NULL AUTO_INCREMENT, `blogId` int NOT NULL, `createdate` datetime NOT NULL, `username` text NULL, `phone` text NULL, `QQ` text NULL, `body` text NULL, `ip` text NULL, `isshow` bit(1) NOT NULL, PRIMARY KEY(`id`) ) ENGINE=MyISAM DEFAULT CHARSET=gbk;  DROP TABLE IF EXISTS `Module`; CREATE TABLE `Module` ( `Id` int(11) NOT NULL AUTO_INCREMENT, `IsDeleted` bit(1) NULL, `ParentId` int NULL, `Name` varchar(256) NULL, `LinkUrl` varchar(256) NULL, `Area` text NULL, `Controller` text NULL, `Action` text NULL, `Icon` varchar(100) NULL, `Code` varchar(10) NULL, `OrderSort` int NOT NULL, `Description` varchar(100) NULL, `IsMenu` bit(1) NOT NULL, `Enabled` bit(1) NOT NULL, `CreateId` int NULL, `CreateBy` varchar(50) NULL, `CreateTime` datetime NULL, `ModifyId` int NULL, `ModifyBy` varchar(50) NULL, `ModifyTime` datetime NULL, PRIMARY KEY(`Id`) ) ENGINE=MyISAM DEFAULT CHARSET=gbk;  DROP TABLE IF EXISTS `ModulePermission`; CREATE TABLE `ModulePermission` ( `Id` int(11) NOT NULL AUTO_INCREMENT, `IsDeleted` bit(1) NULL, `ModuleId` int NOT NULL, `PermissionId` int NOT NULL, `CreateId` int NULL, `CreateBy` varchar(50) NULL, `CreateTime` datetime NULL, `ModifyId` int NULL, `ModifyBy` varchar(50) NULL, `ModifyTime` datetime NULL, PRIMARY KEY(`Id`) ) ENGINE=MyISAM DEFAULT CHARSET=gbk;  DROP TABLE IF EXISTS `OperateLog`; CREATE TABLE `OperateLog` ( `Id` int(11) NOT NULL AUTO_INCREMENT, `IsDeleted` bit(1) NULL, `Area` text NULL, `Controller` text NULL, `Action` text NULL, `IPAddress` text NULL, `Description` text NULL, `LogTime` datetime NULL, 'LoginName' text NULL, `UserId` int NOT NULL, PRIMARY KEY(`Id`) ) ENGINE=MyISAM DEFAULT CHARSET=gbk;  DROP TABLE IF EXISTS `PasswordLib`; CREATE TABLE `PasswordLib` ( `PLID` int(11) NOT NULL AUTO_INCREMENT, `IsDeleted` bit(1) NULL, `plURL` varchar(200) NULL, `plPWD` varchar(100) NULL, `plAccountName` varchar(200) NULL, `plStatus` int NULL, `plErrorCount` int NULL, `plHintPwd` varchar(200) NULL, `plHintquestion` varchar(200) NULL, `plCreateTime` datetime NULL, `plUpdateTime` datetime NULL, `plLastErrTime` datetime NULL, `test` varchar(20000) NULL, PRIMARY KEY(`PLID`) ) ENGINE=MyISAM DEFAULT CHARSET=gbk;  DROP TABLE IF EXISTS `Permission`; CREATE TABLE `Permission` ( `Id` int(11) NOT NULL AUTO_INCREMENT, `IsDeleted` bit(1) NULL, `Code` varchar(10) NULL, `Name` varchar(256) NULL, `OrderSort` int NOT NULL, `Icon` varchar(100) NULL, `Description` varchar(100) NULL, `Enabled` bit(1) NOT NULL, `CreateId` int NULL, `CreateBy` varchar(50) NULL, `CreateTime` datetime NULL, `ModifyId` int NULL, `ModifyBy` varchar(50) NULL, `ModifyTime` datetime NULL, PRIMARY KEY(`Id`) ) ENGINE=MyISAM DEFAULT CHARSET=gbk;  DROP TABLE IF EXISTS `Role`; CREATE TABLE `Role` ( `Id` int(11) NOT NULL AUTO_INCREMENT, `IsDeleted` bit(1) NULL, `Name` varchar(256) NULL, `Description` varchar(100) NULL, `OrderSort` int NOT NULL, `Enabled` bit(1) NOT NULL, `CreateId` int NULL, `CreateBy` varchar(50) NULL, `CreateTime` datetime NULL, `ModifyId` int NULL, `ModifyBy` varchar(50) NULL, `ModifyTime` datetime NULL, PRIMARY KEY(`Id`) ) ENGINE=MyISAM DEFAULT CHARSET=gbk;  DROP TABLE IF EXISTS `RoleModulePermission`; CREATE TABLE `RoleModulePermission` ( `Id` int(11) NOT NULL AUTO_INCREMENT, `IsDeleted` bit(1) NULL, `RoleId` int NOT NULL, `ModuleId` int NOT NULL, `PermissionId` int NULL, `CreateId` int NULL, `CreateBy` varchar(50) NULL, `CreateTime` datetime NULL, `ModifyId` int NULL, `ModifyBy` varchar(50) NULL, `ModifyTime` datetime NULL, PRIMARY KEY(`Id`) ) ENGINE=MyISAM DEFAULT CHARSET=gbk;  DROP TABLE IF EXISTS `sysUserInfo`; CREATE TABLE `sysUserInfo` ( `uID` int(11) NOT NULL AUTO_INCREMENT, `uLoginName` varchar(60) NULL, `uLoginPWD` varchar(60) NULL, `uRealName` varchar(60) NULL, `uStatus` int NOT NULL, `uRemark` varchar(20000) NULL, `uCreateTime datetime NOT NULL, `uUpdateTime datetime NOT NULL, `uLastErrTime datetime NOT NULL, uErrorCount` int NOT NULL, PRIMARY KEY(`uID`) ) ENGINE=MyISAM DEFAULT CHARSET=gbk;  DROP TABLE IF EXISTS `Topic`; CREATE TABLE `Topic` ( `Id` int(11) NOT NULL AUTO_INCREMENT, `tLogo` varchar(200) NULL, `tName` varchar(200) NULL, `tDetail` varchar(400) NULL, `tSectendDetail` varchar(200) NULL, `tIsDelete` bit(1) NOT NULL, `tRead` int NOT NULL, `tCommand` int NOT NULL, `tGood` int NOT NULL, `tCreateTime` datetime NOT NULL, `tUpdateTime` datetime NOT NULL, `tAuthor` varchar(200) NULL, PRIMARY KEY(`Id`) ) ENGINE=MyISAM DEFAULT CHARSET=gbk;  DROP TABLE IF EXISTS `TopicDetail`; CREATE TABLE `TopicDetail` ( `Id` int(11) NOT NULL AUTO_INCREMENT, `TopicId` int NOT NULL, `tdLogo` varchar(200) NULL, `tdName` varchar(200) NULL, `tdConetnt` varchar(20000) NULL, `tdDetail` varchar(400) NULL, `tdSectendDetail` varchar(200) NULL, `tdIsDelete` bit(1) NOT NULL, `tdRead` int NOT NULL, `tdCommand` int NOT NULL, `tdGood` int NOT NULL, `tdCreateTime` datetime NOT NULL, `tdUpdateTime` datetime NOT NULL, `tdTop` int NOT NULL, PRIMARY KEY(`Id`) ) ENGINE=MyISAM DEFAULT CHARSET=gbk;  DROP TABLE IF EXISTS `UserRole`; CREATE TABLE `UserRole` ( `Id` int(11) NOT NULL AUTO_INCREMENT, `IsDeleted` bit(1) NULL, `UserId` int NOT NULL, `RoleId` int NOT NULL, `CreateId` int NULL, `CreateBy` varchar(50) NULL, `CreateTime` datetime NULL, `ModifyId` int NULL, `ModifyBy` varchar(50) NULL, `ModifyTime` datetime NULL, PRIMARY KEY(`Id`) ) ENGINE=MyISAM DEFAULT CHARSET=gbk; 